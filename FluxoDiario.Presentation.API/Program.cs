using FluxoDiario.Presentation.API.Setup.IoC;
using FluxoDiario.Infrastructure.Configurations.IoC.Application;
using FluxoDiario.Infrastructure.Configurations.IoC.Domain;
using FluxoDiario.Infrastructure.Configurations.IoC.DataAccess;
using FluxoDiario.Infrastructure.Configurations.Logs;
using FluxoDiario.Infrastructure.Configurations.IoC.Infrastructure;
using FluxoDiario.DataAccess.Contexts;
using FluxoDiario.Infrastructure.Configurations.MessageQueue;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.SetupAPI()
            .SetupApplication()
            .SetupDomain()
            .SetupDataAccess()
            .SetupInfrastructureGenerics();

        builder.Services.ConfigureRabbitMq(RabbitMqConfigurationType.Publisher);

        builder.Services.SetupDbContexts();

        builder.Services.ConfigureSerilog();

        var app = builder.Build();

        app.Services.EnsureMigrationsApplied();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}