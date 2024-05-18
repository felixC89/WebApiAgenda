using Agenda.Dominio.Dtos;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.Queries.AgendaQueries;
using AutoMapper;
using MediatR;

namespace Agenda.Aplicacion.Handlers.HandlersAgenda
{
    public class GetByIdAgendaTaskHandler : IRequestHandler<GetByIdAgendaTaskQuery, Response<AgendaDto>>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetByIdAgendaTaskHandler(IUnitofWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<AgendaDto>> Handle(GetByIdAgendaTaskQuery request, CancellationToken cancellationToken)
        {
            var resultContacts = await _unitOfWork.RepositoryAgendaRead.GetContactoAgendaByIdAsync(request.idAgenda);

            if (resultContacts == null)
            {
                return new Response<AgendaDto>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: No se logró obtener los datos.",
                    Data = null,
                };
            }

            if (!resultContacts.IsSuccessfullRequest)
            {
                return new Response<AgendaDto>
                {
                    IsSuccessfullRequest = resultContacts.IsSuccessfullRequest,
                    Message = resultContacts.Message,
                    Data = null,
                };
            }

            if (resultContacts.Data == null)
            {
                return new Response<AgendaDto>
                {
                    IsSuccessfullRequest = resultContacts.IsSuccessfullRequest,
                    Message = resultContacts.Message,
                    Data = null,
                };
            }

            var result = _mapper.Map<AgendaDto>(resultContacts.Data);

            return new Response<AgendaDto>
            {
                IsSuccessfullRequest = resultContacts.IsSuccessfullRequest,
                Message = resultContacts.Message,
                Data = result,
            };
        }
    }
}
