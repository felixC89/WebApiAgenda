using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Commands.AgendaCommands;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersAgenda
{
    public class UpdateAgendaTaskHandler : IRequestHandler<UpdateAgendaTaskCommand, Response<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateAgendaTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public Task<Response<bool>> Handle(UpdateAgendaTaskCommand request, CancellationToken cancellationToken)
        {
            var Contact = _mapper.Map<Agendum>(request.AgendaDto);

            var result = _unitOfWork.RepositoryAgendaWrite.UpdateContactoAgenda(Contact);

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
