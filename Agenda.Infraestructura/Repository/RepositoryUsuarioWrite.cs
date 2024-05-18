using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.ModelLocal;

namespace Agenda.Infraestructura.Repository
{
    public class RepositoryUsuarioWrite : IRepositoryUsuarioWrite
    {
        private readonly AgendaDbContext _db;

        public RepositoryUsuarioWrite(AgendaDbContext db)
        {
            _db = db;
        }

        public async Task<Response<bool>> AddUserAsync(Usuario newUser)
        {
            try
            {
                await _db.Usuarios.AddAsync(newUser);

                return new Response<bool>
                {
                    IsSuccessfullRequest = true,
                    Message = $"Operación exitosa.",
                    Data = true,
                };
            }
            catch (Exception ex)
            {
                return new Response<bool>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = false,
                };
            }
        }

        public Response<bool> DeleteUser(long IdUser)
        {
            try
            {
                var usuario = _db.Usuarios.Find(IdUser);

                if (usuario == null)
                {
                    return new Response<bool>
                    {
                        IsSuccessfullRequest = true,
                        Message = $"Error de contexto al realizar la operación.",
                        Data = false,
                    };
                }

                _db.Usuarios.Remove(usuario);

                return new Response<bool>
                {
                    IsSuccessfullRequest = true,
                    Message = $"Operación exitosa.",
                    Data = true,
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

        public Response<bool> UpdateUser(Usuario User)
        {
            try
            {
                _db.Usuarios.Update(User);

                return new Response<bool>
                {
                    IsSuccessfullRequest = true,
                    Message = $"Operación exitosa.",
                    Data = true,
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
