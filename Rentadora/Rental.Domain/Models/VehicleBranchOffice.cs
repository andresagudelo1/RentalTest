namespace Rentadora.Rental.Domain.Models
{
    public partial class VehicleBranchOffice
    {
        public int BranchOfficeVehicleId { get; set; }

        public int BranchOfficeId { get; set; }

        public int VehicleId { get; set; }

        public virtual BranchOffice BranchOffice { get; set; } = null!;

        public virtual Vehicle Vehicle { get; set; } = null!;
    }
}
