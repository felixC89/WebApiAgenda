using Agenda.Dominio.Interfaces;
using Agenda.Infraestructura.ModelLocal;

namespace Agenda.Infraestructura.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AgendaDbContext _context;
        private IRepositoryUsuarioRead _RepositoryUsuarioRead;
        private IRepositoryUsuarioWrite _RepositoryUsuarioWrite;
        private IRepositoryAgendaRead _RepositoryAgendaRead;
        private IRepositoryAgendaWrite _RepositoryAgendaWrite;

        public UnitOfWork(AgendaDbContext context)
        {
            _context = new AgendaDbContext();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        

        IRepositoryAgendaRead IUnitofWork.RepositoryAgendaRead => _RepositoryAgendaRead ?? new RepositoryAgendaRead(_context);

        IRepositoryAgendaWrite IUnitofWork.RepositoryAgendaWrite => _RepositoryAgendaWrite ?? new RepositoryAgendaWrite(_context);

        IRepositoryUsuarioRead IUnitofWork.RepositoryUsuarioRead => _RepositoryUsuarioRead ?? new RepositoryUsuarioRead(_context);

        IRepositoryUsuarioWrite IUnitofWork.RepositoryUsuarioWrite => _RepositoryUsuarioWrite ?? new RepositoryUsuarioWrite(_context);

        public int SaveChanges() => _context.SaveChanges();

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
