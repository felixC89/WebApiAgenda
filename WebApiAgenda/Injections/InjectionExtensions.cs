using Agenda.Aplicacion.Definiciones;
using Agenda.Aplicacion.Interfaces;
using Agenda.Dominio.Interfaces;
using Agenda.Infraestructura.Definiciones;

namespace SWebApiAgenda
{
    public static class InjectionExtensions
    {
        public static IServiceCollection AddInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IConfiguration>(configuration);
            services.AddScoped<IAgendaAplicacion, AgendaAplicacion>();
            services.AddScoped<IAgendaDominio, AgendaDominio>();
            services.AddScoped<IUsuarioAplicacion, UsuarioAplicacion>();
            services.AddScoped<IUsuarioDominio, UsuarioDominio>();
            services.AddScoped<IRepository, RepositoryLocal>();
            return services;
        }
    }
}
