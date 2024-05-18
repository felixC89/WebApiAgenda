using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Queries.UserQueries
{
    public record GetAllUserTaskQuery : IRequest<Response<IEnumerable<UsuarioDto>>>;
}
