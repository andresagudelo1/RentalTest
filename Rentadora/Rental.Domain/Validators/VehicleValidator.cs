using FluentValidation;
using Rentadora.Rental.Domain.Dto;

namespace Rentadora.Rental.Domain.Validators
{
    public class VehicleValidator : AbstractValidator<VehicleDto>
    {
        public VehicleValidator() 
        {
            RuleFor(b => b.Color).NotEmpty()
                .WithMessage($"El color del auto es requerido");
            RuleFor(b => b.FuelType).NotEmpty()
                    .WithMessage("El tipo de combustible es requerido");
            RuleFor(b => b.IsAvailable).NotEmpty()
                    .WithMessage("La disponibilidad del auto requerido");
            RuleFor(b => b.Model).NotEmpty()
                    .WithMessage("El modelo del auto es requerido");
            RuleFor(b => b.PlateNumber).NotEmpty()
                    .WithMessage("La placa del auto es requerida");
        }
    }
}
