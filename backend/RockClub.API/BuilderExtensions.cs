using Microsoft.EntityFrameworkCore;
using RockClub.Shared.Interfaces;
using RockClub.Infra.Persistence;
using RockClub.Infra.Repositories;
using RockClub.Application.ColaboradorCQ.Validators;
using RockClub.Application.ColaboradorCQ.Commands;
using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;


namespace RockClub.API
{
    public static class BuilderExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RockClub", Version = "v1" });
                c.ExampleFilters();
            });

            builder.Services.AddSwaggerExamplesFromAssemblyOf<Program>();


            /* Config Mediator referênciando */
            builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(
                    typeof(CreateColaboradorCommand).Assembly));

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowMyOrigin",
                    builder => builder.WithOrigins("http://localhost:4200")
                                      .AllowAnyMethod()
                                      .AllowAnyHeader());
            });

        }

        // metodo para uso do contexto do database
        public static void AddDatabase(this WebApplicationBuilder builder)
        {
            // Config Banco de dados
            var configurationDb = builder.Configuration;
            builder.Services.AddDbContext<RockClubDbContext>(options => options.UseSqlServer(configurationDb.GetConnectionString("DefaultConnection")));
        }


        // metodos dos servicos de validação
        public static void AddValidations(this WebApplicationBuilder builder)
        {
            // config FluentValidation(obs precisa referenciar apenas 1 classe que ele entende onde
            // fica as classes de validação)
            builder.Services.AddValidatorsFromAssemblyContaining<CreateColaboradorComandValidator>();
            builder.Services.AddFluentValidationAutoValidation();

        }

        // metodo das injeções de dependencias
        public static void AddInjections(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            builder.Services.AddScoped<ISenhaRepository, SenhaRepository>();
        }



    }
}
