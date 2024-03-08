using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Rentadora;
using Rentadora.Rental.Application.Interfaces;
using Rentadora.Rental.Application.Services;
using Rentadora.Rental.Domain.Dto;
using Rentadora.Rental.Domain.Interfaces;
using Rentadora.Rental.Domain.Validators;
using Rentadora.Rental.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddDbContext<TestCarRentalContext>(option => 
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


// Add repositories
builder.Services.AddTransient<IBranchOfficeRepository, BranchOfficeRepository>();
builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();
builder.Services.AddTransient<IVehicleBranchOfficeRepository, VehicleBranchOfficeRepository>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add Application
builder.Services.AddTransient<IBranchOfficeApplication, BranchOfficeApplication>();
builder.Services.AddTransient<IVehicleApplication, VehicleApplication>();
builder.Services.AddTransient<IVehicleBranchOfficeApplication, VehicleBranchOfficeApplication>();

// Add Validators
builder.Services.AddTransient<IValidator<BranchOfficeDto>, BranchOfficeValidator>();
builder.Services.AddTransient<IValidator<VehicleDto>, VehicleValidator>();
builder.Services.AddTransient<IValidator<VehicleBranchOfficeDto>, VehicleBranchOfficeValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
