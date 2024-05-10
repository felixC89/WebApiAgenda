using Agenda.Aplicacion.Dtos;
using Agenda.Aplicacion.Interfaces;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Entidades;
using AutoMapper;

namespace Agenda.Aplicacion.Definiciones
{
    public class AgendaAplicacion : IAgendaAplicacion
    {
        private readonly IAgendaDominio _agendaDominio;
        private readonly IMapper _mapper;
        public AgendaAplicacion(IAgendaDominio agendaDominio, IMapper mapper)
        {
            _agendaDominio = agendaDominio;
            _mapper = mapper;
        }

        public async Task<Dominio.Utilies.Response<bool>> Add(AgendaDto newContacto)
        {
            try
            {
                Agendum newcontact = _mapper.Map<Agendum>(newContacto);
                var requestdomain = await _agendaDominio.Add(newcontact);

                return new Dominio.Utilies.Response<bool>
                {
                    IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                    Message = requestdomain.Message,
                    Data = requestdomain.Data
                };

            }
            catch (Exception ex)
            {
                return new Dominio.Utilies.Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<Dominio.Utilies.Response<bool>> Delete(int id)
        {
            try
            {
                var requestdomain = await _agendaDominio.Delete(id);

                return new Dominio.Utilies.Response<bool>
                {
                    IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                    Message = requestdomain.Message,
                    Data = requestdomain.Data
                };

            }
            catch (Exception ex)
            {
                return new Dominio.Utilies.Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<Dominio.Utilies.Response<AgendaDto>> GetAgendaById(int id)
        {
            try
            {
                var requestdomain = await _agendaDominio.GetAgendaById(id);

                if (requestdomain.IsSuccessfullRequest)
                {
                    return new Dominio.Utilies.Response<AgendaDto>
                    {
                        IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                        Message = requestdomain.Message,
                        Data = _mapper.Map<AgendaDto>(requestdomain.Data)
                    };
                }

                return new Dominio.Utilies.Response<AgendaDto>
                {
                    IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                    Message = requestdomain.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Dominio.Utilies.Response<AgendaDto>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Dominio.Utilies.Response<IEnumerable<AgendaDto>>> GetAllAgenda(int iduser)
        {
            try
            {
                var requestdomain = await _agendaDominio.GetAllAgenda(iduser);

                if (requestdomain.IsSuccessfullRequest)
                {
                    return new Dominio.Utilies.Response<IEnumerable<AgendaDto>>
                    {
                        IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                        Message = requestdomain.Message,
                        Data = _mapper.Map<IEnumerable<AgendaDto>>(requestdomain.Data)
                    };
                }

                return new Dominio.Utilies.Response<IEnumerable<AgendaDto>>
                {
                    IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                    Message = requestdomain.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Dominio.Utilies.Response<IEnumerable<AgendaDto>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Dominio.Utilies.Response<bool>> Update(AgendaDto newContacto)
        {
            try
            {
                Agendum newcontact = _mapper.Map<Agendum>(newContacto);
                var requestdomain = await _agendaDominio.Update(newcontact);

                return new Dominio.Utilies.Response<bool>
                {
                    IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                    Message = requestdomain.Message,
                    Data = requestdomain.Data
                };

            }
            catch (Exception ex)
            {
                return new Dominio.Utilies.Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = false
                };
            }
        }
    }
}
