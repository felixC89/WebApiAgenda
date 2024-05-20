using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Commands.UsersCommands
{
    public record UpdateUserTaskCommand(UsuarioDto userDto) : IRequest<Response<bool>>;
}
