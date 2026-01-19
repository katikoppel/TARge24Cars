using Cars.Core.Dto;
using Cars.Core.ServiceInterface;
using Cars.Data;
using Cars.Models.Cars;
using Microsoft.AspNetCore.Mvc;

namespace Cars.Controllers
{
    public class CarsController : Controller
    {
        private readonly CarsContext _context;
        private readonly ICarServices _carServices;

        public CarsController
            (
                CarsContext context,
                ICarServices carServices
            )

        {
              _context = context;
              _carServices = carServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarsIndexViewModel
                {
                    Id = x.Id,
                    Brand = x.Brand,
                    Model = x.Model,
                    ReleaseYear = x.ReleaseYear,
                    Price = x.Price
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarsCreateUpdateViewModel result = new();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarsCreateUpdateViewModel vm)
        {
            var dto = new CarsDto
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                ReleaseYear = vm.ReleaseYear,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };

            var result = await _carServices.Create(dto);

            if (result != null)
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.DetailAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarsCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.ReleaseYear = car.ReleaseYear;
            vm.Price = car.Price;
            vm.CreatedAt = car.CreatedAt;
            vm.ModifiedAt = car.ModifiedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarsCreateUpdateViewModel vm)
        {
            var dto = new CarsDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                ReleaseYear = vm.ReleaseYear,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt 
            };

            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
