using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Queries.AgendaQueries
{
    public record GetAllAgendaTaskQuery(int idUser) : IRequest<Response<IEnumerable<AgendaDto>>>;
}
