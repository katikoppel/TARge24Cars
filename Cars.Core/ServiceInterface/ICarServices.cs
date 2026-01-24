using Cars.Core.Domain;
using Cars.Core.Dto;

namespace Cars.Core.ServiceInterface
{
    public interface ICarServices
    {
        Task<Car> Create(CarsDto dto);
        Task<Car> DetailAsync(Guid id);
        Task<Car> Update(CarsDto dto);
        Task<Car> Delete(Guid id);
    }
}
