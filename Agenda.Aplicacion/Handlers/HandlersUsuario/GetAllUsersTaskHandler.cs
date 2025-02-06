using Agenda.Dominio.Dtos;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Queries.UsersQueries;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersUsuario
{
    public class GetAllUsersTaskHandler : IRequestHandler<GetAllUserTaskQuery, Response<IEnumerable<UsuarioDto>>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllUsersTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<UsuarioDto>>> Handle(GetAllUserTaskQuery request, CancellationToken cancellationToken)
        {
            var resultUsers = await _unitOfWork.RepositoryUsuarioRead.GetAllUsersAsync();

            if (resultUsers == null)
            {
                return new Response<IEnumerable<UsuarioDto>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación",
                    Data = null,
                };
            }

            if (!resultUsers.IsSuccessfullRequest)
            {
                return new Response<IEnumerable<UsuarioDto>>
                {
                    IsSuccessfullRequest = resultUsers.IsSuccessfullRequest,
                    Message = resultUsers.Message,
                    Data = null,
                };
            }

            if (resultUsers.Data == null)
            {
                return new Response<IEnumerable<UsuarioDto>>
                {
                    IsSuccessfullRequest = resultUsers.IsSuccessfullRequest,
                    Message = resultUsers.Message,
                    Data = null,
                };
            }

            var result = _mapper.Map<IEnumerable<UsuarioDto>>(resultUsers.Data);

            return new Response<IEnumerable<UsuarioDto>>
            {
                IsSuccessfullRequest = true,
                Message = $"Operación exitosa.",
                Data = result,
            };
        }
    }
}
