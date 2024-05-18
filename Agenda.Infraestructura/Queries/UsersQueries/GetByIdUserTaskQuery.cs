using Agenda.Dominio.Dtos;
using Agenda.Dominio.Utilies;
using MediatR;

namespace Agenda.Infraestructura.Queries.UserQueries
{
    public record GetByIdUserTaskQuery(int idUser) : IRequest<Response<UsuarioDto>>;
}
