namespace Rentadora.Rental.Domain.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }

        public string Color { get; set; } = null!;

        public string FuelType { get; set; } = null!;

        public bool IsAvailable { get; set; }

        public string Model { get; set; } = null!;

        public string PlateNumber { get; set; } = null!;

        public int? SeatNumber { get; set; }

        public decimal? Price { get; set; }

        public virtual ICollection<VehicleBranchOffice> VehicleBranchOffices { get; set; } = new List<VehicleBranchOffice>();
    }

}