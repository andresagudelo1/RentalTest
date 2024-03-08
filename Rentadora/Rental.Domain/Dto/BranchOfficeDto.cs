namespace Rentadora.Rental.Domain.Dto
{
    public class BranchOfficeDto
    {
        public int BranchOfficeId { get; set; }
        public string Addres { get; set; } = null!;
        public string City { get; set; } = null!;
        public string Country { get; set; } = null!;
        public string? Email { get; set; }
        public string? PostalCode { get; set; }
        public bool IsRetired { get; set; }
    }
}
