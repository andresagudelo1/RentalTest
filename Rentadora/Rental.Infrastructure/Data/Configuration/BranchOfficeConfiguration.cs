using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentadora.Rental.Domain.Models;

namespace Rentadora.Rental.Infrastructure.Data.Configuration
{
    public class BranchOfficeConfiguration : IEntityTypeConfiguration<BranchOffice>
    {
        public void Configure(EntityTypeBuilder<BranchOffice> entity)
        {
            entity.ToTable("BranchOffice");

            entity.Property(e => e.BranchOfficeId).ValueGeneratedNever();
            entity.Property(e => e.Addres).IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PostalCode)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
