using EvoltisPruebaTecnica.Model;
using FluentValidation;

namespace EvoltisPruebaTecnica.Validators
{
    public class ProfesorValidator: AbstractValidator<Profesor>
    {
        public ProfesorValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre de profesor requerido");
            RuleFor(x => x.Nombre).MaximumLength(15).WithMessage("Exceso de caracteres en el nombre");

            RuleFor(x => x.Apellido).NotEmpty().WithMessage("Nombre de profesor requerido");
            RuleFor(x => x.Apellido).MaximumLength(15).WithMessage("Exceso de caracteres en el nombre");

            RuleFor(x => x.Dni).NotEmpty().WithMessage("DNI de profesor requerido");
            RuleFor(x => x.Dni).Must(BeValidDni).WithMessage("El DNI debe ser tener 8 numeros");
        }

        private bool BeValidDni(int dni)
        {
            const int dniLength = 8;
            return dni > 0 && dni.ToString().Length == dniLength;
        }
    }
}
