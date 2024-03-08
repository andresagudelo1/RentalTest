using Rentadora.Rental.Domain.Dto;

namespace Rentadora.Rental.Application.Interfaces
{
    public interface IVehicleApplication
    {
        IEnumerable<VehicleDto> GetAll();
        Task<VehicleDto> GetById(int id);
        Task<int> Create(VehicleDto entity);
        Task<bool> Update(VehicleDto entity);
        Task<bool> Delete(int id);
    }
}
