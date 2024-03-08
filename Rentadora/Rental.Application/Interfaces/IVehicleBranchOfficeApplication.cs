using Rentadora.Rental.Domain.Dto;

namespace Rentadora.Rental.Application.Interfaces
{
    public interface IVehicleBranchOfficeApplication
    {
        IEnumerable<VehicleBranchOfficeDto> GetAll();
        Task<VehicleBranchOfficeDto> GetById(int id);
        Task<int> Create(VehicleBranchOfficeDto entity);
        Task<bool> Update(VehicleBranchOfficeDto entity);
        Task<bool> Delete(int id);
    }
}
