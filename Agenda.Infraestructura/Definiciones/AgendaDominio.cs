using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;

namespace Agenda.Infraestructura.Definiciones
{
    public class AgendaDominio : IAgendaDominio
    {

        private readonly IRepository _repository;

        public AgendaDominio(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> Add(Agendum newContacto)
        {
            try
            {
                var requestReporitory = await _repository.AddContactoAgenda(newContacto);

                return new Response<bool>
                {
                    IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                    Message = requestReporitory.Message,
                    Data = requestReporitory.Data
                };

            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación en el repositorio: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<Response<bool>> Delete(int id)
        {
            try
            {
                var requestReporitory = await _repository.DeleteContactoAgenda(id);

                return new Response<bool>
                {
                    IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                    Message = requestReporitory.Message,
                    Data = requestReporitory.Data
                };

            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación en el repositorio: {ex.Message}",
                    Data = false
                };
            }
        }

        public async Task<Response<Agendum>> GetAgendaById(int id)
        {
            try
            {
                var requestReporitory = await _repository.GetContactoAgendaById(id);

                if (requestReporitory.IsSuccessfullRequest)
                {
                    return new Response<Agendum>
                    {
                        IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                        Message = requestReporitory.Message,
                        Data = requestReporitory.Data
                    };
                }

                return new Response<Agendum>
                {
                    IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                    Message = requestReporitory.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Response<Agendum>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta en el repositorio: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Response<IEnumerable<Agendum>>> GetAllAgenda(int iduser)
        {
            try
            {
                var requestReporitory = await _repository.GetAllContactsAgenda(iduser);

                if (requestReporitory.IsSuccessfullRequest)
                {
                    return new Response<IEnumerable<Agendum>>
                    {
                        IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                        Message = requestReporitory.Message,
                        Data = requestReporitory.Data
                    };
                }

                return new Response<IEnumerable<Agendum>>
                {
                    IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                    Message = requestReporitory.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Agendum>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta en el repositorio: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Response<bool>> Update(Agendum newContacto)
        {
            try
            {
                var requestReporitory = await _repository.UpdateContactoAgenda(newContacto);

                return new Response<bool>
                {
                    IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                    Message = requestReporitory.Message,
                    Data = requestReporitory.Data
                };

            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación en el repositorio: {ex.Message}",
                    Data = false
                };
            }
        }
    }
}
