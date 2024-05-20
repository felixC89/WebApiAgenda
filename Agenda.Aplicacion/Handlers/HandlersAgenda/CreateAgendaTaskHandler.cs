using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Commands.AgendaCommands;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersAgenda
{
    public class CreateAgendaTaskHandler : IRequestHandler<CreateAgendaTaskCommand, Response<bool>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateAgendaTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(CreateAgendaTaskCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newContact = _mapper.Map<Agendum>(request.AgendaDto);

                var result = await _unitOfWork.RepositoryAgendaWrite.AddContactoAgendaAsync(newContact);

                if (result == null)
                {
                    return new Response<bool>
                    {
                        IsSuccessfullRequest = false,
                        Message = $"Error al realizar la operación: No se logró obtener los datos.",
                        Data = false,
                    };
                }

                if (!result.IsSuccessfullRequest)
                {
                    return new Response<bool>
                    {
                        IsSuccessfullRequest = result.IsSuccessfullRequest,
                        Message = result.Message,
                        Data = result.Data,
                    };
                }

                if (result?.Data == null)
                {
                    return new Response<bool>
                    {
                        IsSuccessfullRequest = result.IsSuccessfullRequest,
                        Message = result.Message,
                        Data = result.Data,
                    };
                }

                await _unitOfWork.SaveChangesAsync();

                return new Response<bool>
                {
                    IsSuccessfullRequest = result.IsSuccessfullRequest,
                    Message = result.Message,
                    Data = result.Data
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = false
                };
            }
        }
    }
}