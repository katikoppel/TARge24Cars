using Cars.Core.Dto;
using Cars.Core.Domain;
using Cars.Core.ServiceInterface;
using Cars.Data;
using Microsoft.EntityFrameworkCore;

namespace Cars.ApplicationServices.Services
{
    public class CarServices : ICarServices
    {
        private readonly CarsContext _context;

        public CarServices
            (
                CarsContext context
            )
        {
             _context = context;
        }

        public async Task<Car> Create(CarsDto dto)
        {
            Car car = new Car();

            car.Id = Guid.NewGuid();
            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.ReleaseYear = dto.ReleaseYear;
            car.Price = dto.Price;
            car.CreatedAt = DateTime.UtcNow;
            car.ModifiedAt = DateTime.UtcNow;

            await _context.Cars.AddAsync(car);
            await _context.SaveChangesAsync();

            return car;
        }
        public async Task<Car> Update(CarsDto dto)
        {
            Car car = new Car();

            car.Id = dto.Id;
            car.Brand = dto.Brand;
            car.Model = dto.Model;
            car.ReleaseYear = dto.ReleaseYear;
            car.Price = dto.Price;
            car.CreatedAt = dto.CreatedAt;
            car.ModifiedAt = DateTime.Now;

            _context.Cars.Update(car);
            await _context.SaveChangesAsync();

            return car;
        }

        public async Task<Car> DetailAsync(Guid id)
        {
            var res = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            return res;
        }

        public async Task<Car> Delete(Guid id)
        {
            var result = await _context.Cars
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Cars.Remove(result);
            await _context.SaveChangesAsync();

            return result;
        }
    }
}
