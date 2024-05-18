using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Commands.AgendaCommands;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersAgenda
{
    public class DeleteAgedaTaskHandler : IRequestHandler<DeleteAgendaTaskCommand, Response<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteAgedaTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<Response<bool>> Handle(DeleteAgendaTaskCommand request, CancellationToken cancellationToken)
        {
            var result = _unitOfWork.RepositoryAgendaWrite.DeleteContactoAgenda(request.idContacto);

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

            _unitOfWork.SaveChanges();

            return Task.FromResult(result);
        }
    }
}
