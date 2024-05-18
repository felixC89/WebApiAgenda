using Agenda.Dominio.Entidades;
using Agenda.Dominio.Utilies;

namespace Agenda.Dominio.Interfaces
{
    public interface IRepositoryUsuarioRead
    {
        //Usuario
        Task<Response<IEnumerable<Usuario>>> GetAllUsersAsync();
        Task<Response<Usuario>> GetUserByIdAsync(int id);
        Task<Response<bool>> isUserValidAsync(Usuario User);
    }
}
