using FluentValidation;
using Rentadora.Rental.Domain.Dto;

namespace Rentadora.Rental.Domain.Validators
{
    public class BranchOfficeValidator : AbstractValidator<BranchOfficeDto>
    {
        public BranchOfficeValidator() 
        {
            RuleFor(b => b.Addres).NotEmpty()
                .WithMessage($"La dirección del local de retiro o devolucion es requerida");
            RuleFor(b => b.City).NotEmpty()
                    .WithMessage("La ciudad del local de retiro o devolucion es requerida");
            RuleFor(b => b.Country).NotEmpty()
                    .WithMessage("El pais del local de retiro o devolucion requerido");
            RuleFor(b => b.Email).NotEmpty()
                    .WithMessage("El email del local de retiro o devolucion");
        }
    }
}
