using Agenda.Aplicacion.Dtos;
using Agenda.Aplicacion.Interfaces;
using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using AutoMapper;

namespace Agenda.Aplicacion.Definiciones
{
    public class UsuarioAplicacion : IUsuarioAplicacion
    {
        private readonly IUsuarioDominio _usuarioDominio;
        private readonly IMapper _mapper;

        public UsuarioAplicacion(IUsuarioDominio agendaDominio, IMapper mapper)
        {
            _usuarioDominio = agendaDominio;
            _mapper = mapper;
        }

        public async Task<Response<bool>> AddUser(UsuarioDto newUser)
        {
            try
            {
                Usuario newuser = _mapper.Map<Usuario>(newUser);
                var requestdomain = await _usuarioDominio.AddUser(newuser);

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

        public async Task<Response<bool>> DeleteUser(int id)
        {
            try
            {
                var requestdomain = await _usuarioDominio.DeleteUser(id);

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

        public async Task<Response<IEnumerable<UsuarioDto>>> GetAllUsers()
        {
            try
            {
                var requestdomain = await _usuarioDominio.GetAllUsers();

                if (requestdomain.IsSuccessfullRequest)
                {
                    return new Dominio.Utilies.Response<IEnumerable<UsuarioDto>>
                    {
                        IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                        Message = requestdomain.Message,
                        Data = _mapper.Map<IEnumerable<UsuarioDto>>(requestdomain.Data)
                    };
                }

                return new Dominio.Utilies.Response<IEnumerable<UsuarioDto>>
                {
                    IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                    Message = requestdomain.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Dominio.Utilies.Response<IEnumerable<UsuarioDto>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Response<UsuarioDto>> GetUsuarioById(int id)
        {
            try
            {
                var requestdomain = await _usuarioDominio.GetUsuarioById(id);

                if (requestdomain.IsSuccessfullRequest)
                {
                    return new Dominio.Utilies.Response<UsuarioDto>
                    {
                        IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                        Message = requestdomain.Message,
                        Data = _mapper.Map<UsuarioDto>(requestdomain.Data)
                    };
                }

                return new Dominio.Utilies.Response<UsuarioDto>
                {
                    IsSuccessfullRequest = requestdomain.IsSuccessfullRequest,
                    Message = requestdomain.Message,
                    Data = null
                };

            }
            catch (Exception ex)
            {
                return new Dominio.Utilies.Response<UsuarioDto>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la consulta: {ex.Message}",
                    Data = null
                };
            }
        }

        public async Task<Response<bool>> UpdateUser(UsuarioDto newUser)
        {
            try
            {
                Usuario newuser = _mapper.Map<Usuario>(newUser);
                var requestdomain = await _usuarioDominio.UpdateUser(newuser);

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
