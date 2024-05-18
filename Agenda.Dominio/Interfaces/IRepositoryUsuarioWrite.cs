using Agenda.Dominio.Entidades;
using Agenda.Dominio.Utilies;

namespace Agenda.Dominio.Interfaces
{
    public interface IRepositoryUsuarioWrite
    {
        //Usuario
        Task<Response<bool>> AddUserAsync(Usuario newUser);
        Response<bool> UpdateUser(Usuario User);
        Response<bool> DeleteUser(long IdUser);
    }
}
