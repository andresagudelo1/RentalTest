using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rentadora.Rental.Domain.Models;

namespace Rentadora.Rental.Infrastructure.Data.Configuration
{
    public class VehicleBranchOfficeConfiguration : IEntityTypeConfiguration<VehicleBranchOffice>
    {
        public void Configure(EntityTypeBuilder<VehicleBranchOffice> entity)
        {
            entity.HasKey(e => e.BranchOfficeVehicleId);

            entity.ToTable("VehicleBranchOffice");

            entity.Property(e => e.BranchOfficeVehicleId).ValueGeneratedNever();

            entity.HasOne(d => d.BranchOffice).WithMany(p => p.VehicleBranchOffices)
                .HasForeignKey(d => d.BranchOfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleBranchOffice_BranchOffice");

            entity.HasOne(d => d.Vehicle).WithMany(p => p.VehicleBranchOffices)
                .HasForeignKey(d => d.VehicleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VehicleBranchOffice_Vehicle");
        }
    }
}
