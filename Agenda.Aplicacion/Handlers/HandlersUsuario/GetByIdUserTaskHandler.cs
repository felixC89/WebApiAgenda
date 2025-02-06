using Agenda.Dominio.Dtos;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Queries.UsersQueries;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersUsuario
{
    public class GetByIdUserTaskHandler : IRequestHandler<GetByIdUserTaskQuery, Response<UsuarioDto>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdUserTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<UsuarioDto>> Handle(GetByIdUserTaskQuery request, CancellationToken cancellationToken)
        {
            var resultUsers = await _unitOfWork.RepositoryUsuarioRead.GetUserByIdAsync(request.idUser);

            if (resultUsers == null)
            {
                return new Response<UsuarioDto>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación",
                    Data = null,
                };
            }

            if (!resultUsers.IsSuccessfullRequest)
            {
                return new Response<UsuarioDto>
                {
                    IsSuccessfullRequest = resultUsers.IsSuccessfullRequest,
                    Message = resultUsers.Message,
                    Data = null,
                };
            }

            if (resultUsers.Data == null)
            {
                return new Response<UsuarioDto>
                {
                    IsSuccessfullRequest = resultUsers.IsSuccessfullRequest,
                    Message = resultUsers.Message,
                    Data = null,
                };
            }

            var result = _mapper.Map<UsuarioDto>(resultUsers.Data);

            return new Response<UsuarioDto>
            {
                IsSuccessfullRequest = true,
                Message = $"Operación exitosa.",
                Data = result,
            };
        }
    }
}
