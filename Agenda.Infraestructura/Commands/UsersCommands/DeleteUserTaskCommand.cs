using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Commands.UsersCommands
{
    public record DeleteUserTaskCommand(int idUser) : IRequest<Response<bool>>;
}
