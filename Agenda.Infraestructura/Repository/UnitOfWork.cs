using Agenda.Dominio.Interfaces;
using Agenda.Infraestructura.ModelLocal;

namespace Agenda.Infraestructura.Repository
{
    public class UnitOfWork : IUnitofWork
    {
        private readonly AgendaDbContext _context;
#pragma warning disable CS0649 // El campo 'UnitOfWork._RepositoryUsuarioRead' nunca se asigna y siempre tendrá el valor predeterminado null
        private IRepositoryUsuarioRead _RepositoryUsuarioRead;
#pragma warning restore CS0649 // El campo 'UnitOfWork._RepositoryUsuarioRead' nunca se asigna y siempre tendrá el valor predeterminado null
#pragma warning disable CS0649 // El campo 'UnitOfWork._RepositoryUsuarioWrite' nunca se asigna y siempre tendrá el valor predeterminado null
        private IRepositoryUsuarioWrite _RepositoryUsuarioWrite;
#pragma warning restore CS0649 // El campo 'UnitOfWork._RepositoryUsuarioWrite' nunca se asigna y siempre tendrá el valor predeterminado null
#pragma warning disable CS0649 // El campo 'UnitOfWork._RepositoryAgendaRead' nunca se asigna y siempre tendrá el valor predeterminado null
        private IRepositoryAgendaRead _RepositoryAgendaRead;
#pragma warning restore CS0649 // El campo 'UnitOfWork._RepositoryAgendaRead' nunca se asigna y siempre tendrá el valor predeterminado null
#pragma warning disable CS0649 // El campo 'UnitOfWork._RepositoryAgendaWrite' nunca se asigna y siempre tendrá el valor predeterminado null
        private IRepositoryAgendaWrite _RepositoryAgendaWrite;
#pragma warning restore CS0649 // El campo 'UnitOfWork._RepositoryAgendaWrite' nunca se asigna y siempre tendrá el valor predeterminado null

#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning disable CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
        public UnitOfWork(AgendaDbContext context)
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
#pragma warning restore CS8618 // Un campo que no acepta valores NULL debe contener un valor distinto de NULL al salir del constructor. Considere la posibilidad de declararlo como que admite un valor NULL.
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
