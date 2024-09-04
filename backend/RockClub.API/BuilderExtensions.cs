using Microsoft.EntityFrameworkCore;
using RockClub.Shared.Interfaces;
using RockClub.Infra.Persistence;
using RockClub.Services.Colaborador;

namespace RockClub.API
{
    public static class BuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

        }

        // metodo para uso do contexto do database
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            // Config Banco de dados
            var configurationDb = builder.Configuration;
            builder.Services.AddDbContext<RockClubDbContext>(options => options.UseSqlServer(configurationDb.GetConnectionString("DefaultConnection")));
        }


        // metodo das injeções de dependencias
        public static void AddInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IColaboradorService, ColaboradorService>();
        }
    }
}
