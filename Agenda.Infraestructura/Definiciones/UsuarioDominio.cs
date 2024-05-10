using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;

namespace Agenda.Infraestructura.Definiciones
{
    public class UsuarioDominio : IUsuarioDominio
    {
        private readonly IRepository _repository;

        public UsuarioDominio(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Response<bool>> AddUser(Usuario newUser)
        {
            try
            {
                var requestReporitory = await _repository.AddUser(newUser);

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

        public async Task<Response<bool>> DeleteUser(int id)
        {
            try
            {
                var requestReporitory = await _repository.DeleteUser(id);

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

        public async Task<Response<IEnumerable<Usuario>>> GetAllUsers()
        {
            try
            {
                var requestReporitory = await _repository.GetAllUsers();

                if (requestReporitory.IsSuccessfullRequest)
                {
                    return new Response<IEnumerable<Usuario>>
                    {
                        IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                        Message = requestReporitory.Message,
                        Data = requestReporitory.Data
                    };
                }

                return new Response<IEnumerable<Usuario>>
                {
                    IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                    Message = requestReporitory.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Usuario>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta en el repositorio: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Response<Usuario>> GetUsuarioById(int id)
        {
            try
            {
                var requestReporitory = await _repository.GetUserById(id);

                if (requestReporitory.IsSuccessfullRequest)
                {
                    return new Response<Usuario>
                    {
                        IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                        Message = requestReporitory.Message,
                        Data = requestReporitory.Data
                    };
                }

                return new Response<Usuario>
                {
                    IsSuccessfullRequest = requestReporitory.IsSuccessfullRequest,
                    Message = requestReporitory.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Response<Usuario>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta en el repositorio: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Response<bool>> UpdateUser(Usuario newUser)
        {
            try
            {
                var requestReporitory = await _repository.UpdateUser(newUser);

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
