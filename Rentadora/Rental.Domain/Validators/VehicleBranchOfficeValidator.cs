using FluentValidation;
using Rentadora.Rental.Domain.Dto;

namespace Rentadora.Rental.Domain.Validators
{
    public class VehicleBranchOfficeValidator : AbstractValidator<VehicleBranchOfficeDto>
    {
        public VehicleBranchOfficeValidator() 
        {
            RuleFor(b => b.BranchOfficeId).NotEmpty()
                .WithMessage($"La dirección del local de retiro o devolucion es requerida");
            RuleFor(b => b.VehicleId).NotEmpty()
                    .WithMessage("La ciudad del local de retiro o devolucion es requerida");
        }
    }
}
