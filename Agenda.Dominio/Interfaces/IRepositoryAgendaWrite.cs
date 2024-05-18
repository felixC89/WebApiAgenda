using Agenda.Dominio.Entidades;
using Agenda.Dominio.Utilies;

namespace Agenda.Dominio.Interfaces
{
    public interface IRepositoryAgendaWrite
    {
        //Agenda
        Task<Response<bool>> AddContactoAgendaAsync(Agendum newContacto);
        Response<bool> UpdateContactoAgenda(Agendum Contacto);
        Response<bool> DeleteContactoAgenda(long IdContacto);

    }
}
