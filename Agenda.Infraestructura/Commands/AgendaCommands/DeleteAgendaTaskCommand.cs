using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Commands.AgendaCommands
{
    public record DeleteAgendaTaskCommand(int idContacto) : IRequest<Response<bool>>;
}
