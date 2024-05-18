using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.ModelLocal;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infraestructura.Repository
{
    public class RepositoryUsuarioRead : IRepositoryUsuarioRead
    {
        private readonly AgendaDbContext _db;

        public RepositoryUsuarioRead(AgendaDbContext db)
        {
            _db = db;
        }

        public async Task<Response<IEnumerable<Usuario>>> GetAllUsersAsync()
        {
            try
            {

                var result = await _db.Usuarios.ToListAsync();

                if (result == null || result.Count == 0)
                {
                    return new Response<IEnumerable<Usuario>>
                    {
                        IsSuccessfullRequest = true,
                        Message = $"No se encontraron registros.",
                        Data = null,
                    };
                }

                return new Response<IEnumerable<Usuario>>
                {
                    IsSuccessfullRequest = true,
                    Message = $"Operación exitosa.",
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Usuario>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = null,
                };
            }

        }

        public async Task<Response<Usuario>> GetUserByIdAsync(int id)
        {
            try
            {
                var result = await _db.Usuarios.FirstAsync(a => a.Iduser == id);

                if (result == null || result.Iduser == 0)
                {
                    return new Response<Usuario>
                    {
                        IsSuccessfullRequest = true,
                        Message = $"No se encontraron registros.",
                        Data = null,
                    };
                }

                return new Response<Usuario>
                {
                    IsSuccessfullRequest = true,
                    Message = $"Operación exitosa.",
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new Response<Usuario>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = null,
                };
            }

        }

        public async Task<Response<bool>> isUserValidAsync(Usuario User)
        {
            try
            {
                var user = await _db.Usuarios.FirstAsync(a => a.Username == User.Username && a.Password == User.Password);

                if (user == null || user.Iduser == 0)
                {
                    return new Response<bool>
                    {
                        IsSuccessfullRequest = true,
                        Message = $"No se encontraron registros.",
                        Data = false,
                    };
                }

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
    }
}
