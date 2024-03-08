using Rentadora.Rental.Domain.Interfaces;
using Rentadora.Rental.Domain.Models;

namespace Rentadora.Rental.Infrastructure.Repositories
{
    public class BranchOfficeRepository : Repository<BranchOffice>, IBranchOfficeRepository
    {
        private readonly TestCarRentalContext _context;
        public BranchOfficeRepository(TestCarRentalContext context) : base(context) 
        {
            _context = context;
        }
    }
}
