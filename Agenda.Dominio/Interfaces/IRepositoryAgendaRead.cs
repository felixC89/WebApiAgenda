using Agenda.Dominio.Entidades;
using Agenda.Dominio.Utilies;

namespace Agenda.Dominio.Interfaces
{
    public interface IRepositoryAgendaRead
    {
        //Agenda
        Task<Response<IEnumerable<Agendum>>> GetAllContactsAgendaAsync(int iduser);
        Task<Response<Agendum>> GetContactoAgendaByIdAsync(int id);

    }
}
