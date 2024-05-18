using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Commands.AgendaCommands
{
    public record CreateUserTaskCommand(UsuarioDto UserDto) : IRequest<Response<bool>>; 
}
