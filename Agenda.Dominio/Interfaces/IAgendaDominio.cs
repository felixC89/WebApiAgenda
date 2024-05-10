using Agenda.Dominio.Entidades;
using Agenda.Dominio.Utilies;
namespace Agenda.Dominio.Interfaces
{
    public interface IAgendaDominio
    {
        Task<Response<IEnumerable<Agendum>>> GetAllAgenda(int iduser);
        Task<Dominio.Utilies.Response<Agendum>> GetAgendaById(int id);
        Task<Dominio.Utilies.Response<bool>> Add(Agendum newContacto);
        Task<Dominio.Utilies.Response<bool>> Update(Agendum newContacto);
        Task<Dominio.Utilies.Response<bool>> Delete(int id);
    }
}
