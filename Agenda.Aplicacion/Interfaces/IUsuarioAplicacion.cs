using Agenda.Aplicacion.Dtos;

namespace Agenda.Aplicacion.Interfaces
{
    public interface IUsuarioAplicacion
    {
        Task<Dominio.Utilies.Response<IEnumerable<UsuarioDto>>> GetAllUsers();
        Task<Dominio.Utilies.Response<UsuarioDto>> GetUsuarioById(int id);
        Task<Dominio.Utilies.Response<bool>> isValidUser(UsuarioDto user);
        Task<Dominio.Utilies.Response<bool>> AddUser(UsuarioDto newUsuario);
        Task<Dominio.Utilies.Response<bool>> UpdateUser(UsuarioDto Usuario);
        Task<Dominio.Utilies.Response<bool>> DeleteUser(int id);
    }
}
