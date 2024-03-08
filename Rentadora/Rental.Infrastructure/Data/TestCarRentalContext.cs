using Microsoft.EntityFrameworkCore;
using Rentadora.Rental.Domain.Models;

namespace Rentadora;

public partial class TestCarRentalContext : DbContext
{
    public TestCarRentalContext()
    {
    }

    public TestCarRentalContext(DbContextOptions<TestCarRentalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BranchOffice> BranchOffices { get; set; }

    public virtual DbSet<Vehicle> Vehicles { get; set; }

    public virtual DbSet<VehicleBranchOffice> VehicleBranchOffices { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TestCarRentalContext).Assembly);
    }
}
