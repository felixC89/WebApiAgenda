using Agenda.Dominio.Entidades;
using Agenda.Dominio.Interfaces;
using Agenda.Dominio.Utilies;
using Agenda.Infraestructura.ModelLocal;

namespace Agenda.Infraestructura.Repository
{
    public class RepositoryAgendaWrite : IRepositoryAgendaWrite
    {
        private readonly AgendaDbContext _db;

        public RepositoryAgendaWrite(AgendaDbContext db)
        {
            _db = db;
        }

        public async Task<Response<bool>> AddContactoAgendaAsync(Agendum newContacto)
        {
            try
            {
                await _db.Agenda.AddAsync(newContacto);

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

        public Response<bool> DeleteContactoAgenda(long IdContacto)
        {
            try
            {
                var contacto = _db.Agenda.Find(IdContacto);

                if (contacto == null)
                {
                    return new Response<bool>
                    {
                        IsSuccessfullRequest = true,
                        Message = $"Error de contexto al realizar la operación.",
                        Data = false,
                    };
                }


                _db.Agenda.Remove(contacto);

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

        public Response<bool> UpdateContactoAgenda(Agendum Contacto)
        {
            try
            {
                _db.Agenda.Update(Contacto);

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
