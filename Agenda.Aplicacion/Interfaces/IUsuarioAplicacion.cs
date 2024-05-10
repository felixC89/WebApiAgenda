using Agenda.Aplicacion.Dtos;

namespace Agenda.Aplicacion.Interfaces
{
    public interface IUsuarioAplicacion
    {
        Task<Dominio.Utilies.Response<IEnumerable<UsuarioDto>>> GetAllUsers();
        Task<Dominio.Utilies.Response<UsuarioDto>> GetUsuarioById(int id);
        Task<Dominio.Utilies.Response<bool>> AddUser(UsuarioDto newContacto);
        Task<Dominio.Utilies.Response<bool>> UpdateUser(UsuarioDto newContacto);
        Task<Dominio.Utilies.Response<bool>> DeleteUser(int id);
    }
}
