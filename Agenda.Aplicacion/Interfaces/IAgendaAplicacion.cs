using Agenda.Aplicacion.Dtos;

namespace Agenda.Aplicacion.Interfaces
{
    public interface IAgendaAplicacion
    {
        Task<Dominio.Utilies.Response<IEnumerable<AgendaDto>>> GetAllAgenda(int iduser);
        Task<Dominio.Utilies.Response<AgendaDto>> GetAgendaById(int id);
        Task<Dominio.Utilies.Response<bool>> Add(AgendaDto newContacto);
        Task<Dominio.Utilies.Response<bool>> Update(AgendaDto newContacto);
        Task<Dominio.Utilies.Response<bool>> Delete(int id);
    }
}
