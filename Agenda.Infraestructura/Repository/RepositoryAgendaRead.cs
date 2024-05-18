using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.ModelLocal;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infraestructura.Repository
{
    public class RepositoryAgendaRead : IRepositoryAgendaRead
    {
        private readonly AgendaDbContext _db;

        public RepositoryAgendaRead(AgendaDbContext db)
        {
            _db = db;
        }

        public async Task<Response<IEnumerable<Agendum>>> GetAllContactsAgendaAsync(int iduser)
        {
            try
            {
                var result = await _db.Agenda.Where(a => a.IdUser == iduser).ToListAsync();

                if (result == null || result.Count == 0)
                {
                    return new Response<IEnumerable<Agendum>>
                    {
                        IsSuccessfullRequest = true,
                        Message = $"No se encontraron registros.",
                        Data = null,
                    };
                }

                return new Response<IEnumerable<Agendum>>
                {
                    IsSuccessfullRequest = true,
                    Message = $"Operación exitosa.",
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<Agendum>>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = null,
                };
            }

        }

        public async Task<Response<Agendum>> GetContactoAgendaByIdAsync(int id)
        {
            try
            {
                var result = await _db.Agenda.FirstAsync(a => a.IdAgenda == id);

                if (result == null || result.IdAgenda == 0)
                {
                    return new Response<Agendum>
                    {
                        IsSuccessfullRequest = true,
                        Message = $"No se encontraron registros.",
                        Data = null,
                    };
                }

                return new Response<Agendum>
                {
                    IsSuccessfullRequest = true,
                    Message = $"Operación exitosa.",
                    Data = result,
                };
            }
            catch (Exception ex)
            {
                return new Response<Agendum>
                {
                    IsSuccessfullRequest = false,
                    Message = $"Error al realizar la operación: {ex.Message}",
                    Data = null,
                };
            }


        }

    }
}
