using Agenda.Dominio.Entidades;
using Agenda.Dominio.Utilies;

namespace Agenda.Dominio.Interfaces
{
    public interface IUsuarioDominio
    {
        Task<Response<IEnumerable<Usuario>>> GetAllUsers();
        Task<Dominio.Utilies.Response<Usuario>> GetUsuarioById(int id);
        Task<Dominio.Utilies.Response<bool>> AddUser(Usuario newUser);
        Task<Dominio.Utilies.Response<bool>> UpdateUser(Usuario newUser);
        Task<Dominio.Utilies.Response<bool>> DeleteUser(int id);
    }
}
