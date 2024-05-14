using Agenda.Aplicacion.Dtos;
using FluentValidation;

namespace Agenda.Aplicacion.Validator
{
    public class UserValidator : AbstractValidator<UsuarioDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Username)
           .NotEmpty()
           .WithMessage("El usuario es requerido");

            RuleFor(x => x.Password)
           .NotEmpty()
           .WithMessage("La contraseña es requerida");
        }
    }
}
