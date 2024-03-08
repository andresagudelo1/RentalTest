using Rentadora.Rental.Domain.Dto;

namespace Rentadora.Rental.Application.Interfaces
{
    public interface IBranchOfficeApplication
    {
        IEnumerable<BranchOfficeDto> GetAll();
        Task<BranchOfficeDto> GetById(int id);
        Task<int> Create(BranchOfficeDto entity);
        Task<bool> Update(BranchOfficeDto entity);
        Task<bool> Delete(int id);
    }
}
