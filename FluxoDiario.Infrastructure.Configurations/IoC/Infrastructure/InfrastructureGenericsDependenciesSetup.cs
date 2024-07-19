using FluxoDiario.Application.Files;
using FluxoDiario.Domain.Events;
using FluxoDiario.Domain.Factories.Relatorios.Builders;
using FluxoDiario.Infrastructure.Generic.Factories.Relatorios;
using FluxoDiario.Infrastructure.Generic.Files;
using FluxoDiario.Infrastructure.Generic.Publishers;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDiario.Infrastructure.Configurations.IoC.Infrastructure
{
    public static class InfrastructureGenericsDependenciesSetup
    {
        public static IServiceCollection SetupInfrastructureGenerics(this IServiceCollection services)
        {
            services.AddScoped<IEventPublisher, EventPublisher>();

            services.SetupRelatoriosContext();

            return services;
        }

        private static void SetupRelatoriosContext(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioBuilderFactory, RelatorioBuilderFactory>();
            services.AddScoped<IFileWriter, LocalFileWriter>();
            services.AddScoped<IFileReader, LocalJsonFileReader>();
        }
    }
}
