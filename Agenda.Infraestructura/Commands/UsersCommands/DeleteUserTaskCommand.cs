using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Commands.AgendaCommands
{
    public record DeleteUserTaskCommand(int idUser) : IRequest<Response<bool>>;
}
