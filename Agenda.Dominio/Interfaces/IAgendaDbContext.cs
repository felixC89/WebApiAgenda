using Agenda.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Agenda.Infraestructura.ModelLocal
{
    public interface IAgendaDbContext
    {
        DbSet<Agendum> Agenda { get; set; }
        DbSet<Usuario> Usuarios { get; set; }
    }
}