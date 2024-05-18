using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Commands.AgendaCommands
{
    public record UpdateAgendaTaskCommand(AgendaDto AgendaDto) : IRequest<Response<bool>>;
}
