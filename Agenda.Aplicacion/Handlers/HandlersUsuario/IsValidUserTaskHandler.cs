using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Queries.UserQueries;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersUsuario
{
    public class IsValidUserTaskHandler : IRequestHandler<IsValidUserTaskQuery, Response<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public IsValidUserTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(IsValidUserTaskQuery request, CancellationToken cancellationToken)
        {
            var User = _mapper.Map<Usuario>(request.User);

            var resultUser = await _unitOfWork.RepositoryUsuarioRead.isUserValidAsync(User);

            if (resultUser == null)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación",
                    Data = false,
                };
            }

            if (!resultUser.IsSuccessfullRequest)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = resultUser.IsSuccessfullRequest,
                    Message = resultUser.Message,
                    Data = false,
                };
            }

            if (resultUser?.Data == null)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = resultUser.IsSuccessfullRequest,
                    Message = resultUser.Message,
                    Data = false,
                };
            }

            return new Response<bool>
            {
                IsSuccessfullRequest = true,
                Message = $"Operación exitosa.",
                Data = resultUser.Data,
            };
        }
    }
}
