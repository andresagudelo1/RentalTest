using Rentadora.Rental.Domain.Interfaces;
using Rentadora.Rental.Domain.Models;

namespace Rentadora.Rental.Infrastructure.Repositories
{
    public class VehicleRepository : Repository<Vehicle>, IVehicleRepository
    {
        private readonly TestCarRentalContext _context;
        public VehicleRepository(TestCarRentalContext context) : base(context)
        {
            _context = context;
        }
    }
}
