using Agenda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Dominio.Interfaces
{
    public interface IAgendaDbContext
    {
        DbSet<Agendum> Agenda { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
    }
}