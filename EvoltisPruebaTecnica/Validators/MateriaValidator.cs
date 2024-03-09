using EvoltisPruebaTecnica.Model;
using FluentValidation;

namespace EvoltisPruebaTecnica.Validators
{
    public class MateriaValidator: AbstractValidator<Materia>
    { 
        public MateriaValidator() 
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("Nombre de materia requerido");
            RuleFor(x => x.Nombre).MaximumLength(50).WithMessage("Exceso de caracteres en el nombre");

            RuleFor(x => x.Duracion).NotEmpty().WithMessage("Duración de alumno requerida");
            RuleFor(x => x.Duracion).Must(BeValidDuracion).WithMessage("Duración debe ser bimestral, cuatrimestral o anual");
        }

        private bool BeValidDuracion(string duracion)
        {
            string[] opcionesValidas = { "bimestral", "cuatrimestral", "anual" };
            return !string.IsNullOrEmpty(duracion) && opcionesValidas.Contains(duracion.ToLower());
        }
    }
}
