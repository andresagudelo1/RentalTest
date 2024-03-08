using Rentadora.Rental.Domain.Interfaces;
using Rentadora.Rental.Domain.Models;

namespace Rentadora.Rental.Infrastructure.Repositories
{
    public class VehicleBranchOfficeRepository : Repository<VehicleBranchOffice>, IVehicleBranchOfficeRepository
    {
        private readonly TestCarRentalContext _context;
        public VehicleBranchOfficeRepository(TestCarRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
