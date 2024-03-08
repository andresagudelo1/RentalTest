namespace Rentadora.Rental.Domain.Models
{
    public partial class BranchOffice
    {
        public int BranchOfficeId { get; set; }

        public string Addres { get; set; } = null!;

        public string City { get; set; } = null!;

        public string Country { get; set; } = null!;

        public string? Email { get; set; }

        public string? PostalCode { get; set; }

        public bool IsRetired { get; set; }

        public virtual ICollection<VehicleBranchOffice> VehicleBranchOffices { get; set; } = new List<VehicleBranchOffice>();
    }
}
