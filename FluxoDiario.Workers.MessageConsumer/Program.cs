using Microsoft.Extensions.Hosting;
using FluxoDiario.Infrastructure.Configurations.MessageQueue;
using FluxoDiario.Infrastructure.Configurations.Logs;
using FluxoDiario.Infrastructure.Configurations.IoC.Domain;
using FluxoDiario.Infrastructure.Configurations.IoC.Application;
using FluxoDiario.Infrastructure.Configurations.IoC.DataAccess;
using FluxoDiario.DataAccess.Contexts;
using Microsoft.Extensions.DependencyInjection;
using FluxoDiario.Workers.MessageConsumer;
using FluxoDiario.Infrastructure.Generic.Process;
using FluxoDiario.Infrastructure.Configurations.IoC.Infrastructure;

var hostBuilder = Host.CreateDefaultBuilder();

hostBuilder.ConfigureServices(services =>
{
    services.ConfigureRabbitMq(RabbitMqConfigurationType.Consumer)
        .ConfigureSerilog()
        .SetupDomain()
        .SetupApplication()
        .SetupDataAccess()
        .SetupDataAccess()
        .SetupDbContexts()
        .SetupInfrastructureGenerics();


    services.AddSingleton<CancellationTokenProvider>();
    services.AddSingleton<ICancellationTokenProvider, CancellationTokenProvider>();

    services.AddHostedService<Worker>();
});

var host = hostBuilder.Build();

host.Services.EnsureMigrationsApplied();

await host.RunAsync();