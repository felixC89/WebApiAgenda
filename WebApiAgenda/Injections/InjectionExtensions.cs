using Agenda.Aplicacion.Validator;
using Agenda.Dominio.Dtos;
using Agenda.Dominio.Interfaces;
using Agenda.Infraestructura.ModelLocal;
using Agenda.Infraestructura.Repository;
using FluentValidation;

namespace SWebApiAgenda
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            //services.AddScoped<IAgendaAplicacion, AgendaAplicacion>();
            //services.AddScoped<IAgendaDominio, AgendaDominio>();
            //services.AddScoped<IUsuarioAplicacion, UsuarioAplicacion>();
            //services.AddScoped<IUsuarioDominio, UsuarioDominio>();
            services.AddScoped<IUnitofWork, UnitOfWork>();
            services.AddScoped<IValidator<UsuarioDto>, UserValidator>();
            services.AddScoped<IRepositoryAgendaRead, RepositoryAgendaRead>();
            services.AddScoped<IRepositoryAgendaWrite, RepositoryAgendaWrite>();
            services.AddScoped<IRepositoryUsuarioRead, RepositoryUsuarioRead>();
            services.AddScoped<IRepositoryUsuarioWrite, RepositoryUsuarioWrite>();
            services.AddScoped<IAgendaDbContext, AgendaDbContext>();
            return services;
        }
    }
}
