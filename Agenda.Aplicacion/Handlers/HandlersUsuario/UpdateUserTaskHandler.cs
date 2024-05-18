using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Commands.AgendaCommands;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersUsuario
{
    public class UpdateUserTaskHandler : IRequestHandler<UpdateUserTaskCommand, Response<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateUserTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<Response<bool>> Handle(UpdateUserTaskCommand request, CancellationToken cancellationToken)
        {

            var User = _mapper.Map<Usuario>(request.userDto);

            var result = _unitOfWork.RepositoryUsuarioWrite.UpdateUser(User);

            if (result == null)
            {
                return Task.FromResult(new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación",
                    Data = false,
                });
            }

            if (!result.IsSuccessfullRequest)
            {
                return Task.FromResult(
                new Response<bool>
                {
                    IsSuccessfullRequest = result.IsSuccessfullRequest,
                    Message = result.Message,
                    Data = result.Data,
                });
            }

            if (!result.Data)
            {
                return Task.FromResult(
                new Response<bool>
                {
                    IsSuccessfullRequest = result.IsSuccessfullRequest,
                    Message = result.Message,
                    Data = result.Data,
                });
            }

                _unitOfWork.SaveChangesAsync();

            return Task.FromResult(result);
        }
    }
}
