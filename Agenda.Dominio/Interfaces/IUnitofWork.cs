namespace Agenda.Dominio.Interfaces
{
    public interface IUnitofWork : IDisposable
    {
        IRepositoryAgendaRead RepositoryAgendaRead { get; }
        IRepositoryAgendaWrite RepositoryAgendaWrite { get; }
        IRepositoryUsuarioRead RepositoryUsuarioRead { get; }
        IRepositoryUsuarioWrite RepositoryUsuarioWrite { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}
