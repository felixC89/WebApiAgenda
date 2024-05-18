using Agenda.Infraestructura.ModelLocal;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SWebApiAgenda;

namespace WebApiAgenda
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            string _MyCors = "MyCors";

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<AgendaDbContext>(c => c.UseSqlServer(builder.Configuration.GetConnectionString("AgendaDatabaseLocal")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddMapper();
            builder.Services.AddInjection(builder.Configuration);
            builder.Services.AddCors(cors =>
            {
                cors.AddPolicy(_MyCors, builder =>
                {
                    builder
                    .SetIsOriginAllowed(origin => new Uri(origin).Host == "localhost")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });
            builder.Services.AddMediatR(Cfg => Cfg.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //Se agrega el ! al if para que funcione en azure o iis, en localVS debe quitarse
            //if (!app.Environment.IsDevelopment())
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors(_MyCors);

            app.MapControllers();

            app.Run();
        }
    }
}
