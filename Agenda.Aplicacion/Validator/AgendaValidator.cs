using Agenda.Dominio.Dtos;
using FluentValidation;

namespace Agenda.Aplicacion.Validator
{
    public class AgendaValidator : AbstractValidator<AgendaDto>
    {
        public AgendaValidator()
        {
            RuleFor(x => x.Nombre)
                .NotEmpty().WithMessage("El nombre es obligatorio.");

            RuleFor(x => x.Apellido)
                .NotEmpty()
                .WithMessage("El apellido es obligatorio.");

            RuleFor(x => x.Nacionalidad)
                .NotEmpty()
                .WithMessage("La nacionalidad es obligatoria.");

            RuleFor(x => x.Telefono)
                .NotEmpty();

            RuleFor(x => x.Correo)
                .NotEmpty()
                .EmailAddress()
                .MaximumLength(255)
                .WithMessage("El correo no es valido.");

            RuleFor(x => x.FechaNacimiento)
                .NotEmpty()
                .WithMessage("La fecha de nacimiento es obligatoria.");

            RuleFor(x => x.Edad)
                .NotEmpty()
                .WithMessage("La edad es obligatoria.");

            RuleFor(x => x.IdUser)
                .NotEmpty()
                .WithMessage("El id del usuario es obligatorio.");

        }
    }
}
