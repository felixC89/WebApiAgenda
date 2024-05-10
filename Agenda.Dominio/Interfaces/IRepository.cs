using Agenda.Dominio.Entidades;
using Agenda.Dominio.Utilies;

namespace Agenda.Dominio.Interfaces
{
    public interface IRepository
    {
        //Agenda
        Task<Response<IEnumerable<Agendum>>> GetAllContactsAgenda(int iduser);
        Task<Response<Agendum>> GetContactoAgendaById(int id);
        Task<Response<bool>> AddContactoAgenda(Agendum newContacto);
        Task<Response<bool>> UpdateContactoAgenda(Agendum newContacto);
        Task<Response<bool>> DeleteContactoAgenda(int id);

        //Usuario
        Task<Response<IEnumerable<Usuario>>> GetAllUsers();
        Task<Response<Usuario>> GetUserById(int id);
        Task<Response<bool>> AddUser(Usuario newUser);
        Task<Response<bool>> UpdateUser(Usuario newUser);
        Task<Response<bool>> DeleteUser(int id);
    }
}
