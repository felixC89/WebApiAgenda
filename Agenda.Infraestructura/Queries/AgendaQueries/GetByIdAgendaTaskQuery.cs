using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Queries.AgendaQueries
{
    public record GetByIdAgendaTaskQuery(int idAgenda) : IRequest<Response<AgendaDto>>;
}
