using Agenda.Dominio.Dtos;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Queries.AgendaQueries;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersAgenda
{
    public class GetAllAgendaTaskHandler : IRequestHandler<GetAllAgendaTaskQuery, Response<IEnumerable<AgendaDto>>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetAllAgendaTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<AgendaDto>>> Handle(GetAllAgendaTaskQuery request, CancellationToken cancellationToken)
        {

            var resultContacts = await _unitOfWork.RepositoryAgendaRead.GetAllContactsAgendaAsync(request.idUser);

            if (resultContacts == null)
            {
                return new Response<IEnumerable<AgendaDto>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: No se logró obtener los datos.",
                    Data = null,
                };
            }

            if (!resultContacts.IsSuccessfullRequest)
            {
                return new Response<IEnumerable<AgendaDto>>
                {
                    IsSuccessfullRequest = resultContacts.IsSuccessfullRequest,
                    Message = resultContacts.Message,
                    Data = null,
                };
            }

            if (resultContacts.Data == null)
            {
                return new Response<IEnumerable<AgendaDto>>
                {
                    IsSuccessfullRequest = resultContacts.IsSuccessfullRequest,
                    Message = resultContacts.Message,
                    Data = null,
                };
            }

            var result = _mapper.Map<IEnumerable<AgendaDto>>(resultContacts.Data);

            return new Response<IEnumerable<AgendaDto>>
            {
                IsSuccessfullRequest = resultContacts.IsSuccessfullRequest,
                Message = resultContacts.Message,
                Data = result,
            };

        }
    }
}
