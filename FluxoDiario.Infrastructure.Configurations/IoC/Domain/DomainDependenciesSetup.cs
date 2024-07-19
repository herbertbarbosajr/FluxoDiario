using FluxoDiario.Domain.Factories.FluxoDiario;
using FluxoDiario.Domain.Factories.FluxoDiario.Interfaces;
using FluxoDiario.Domain.Services.FluxoDiario;
using FluxoDiario.Domain.Services.Relatorios;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDiario.Infrastructure.Configurations.IoC.Domain
{
    public static class DomainDependenciesSetup
    {
        public static IServiceCollection SetupDomain(this IServiceCollection services)
        {
            services.SetupFluxoDiarioContext();
            services.SetupRelatoriosContext();

            return services;
        }

        private static void SetupFluxoDiarioContext(this IServiceCollection services)
        {
            services.AddScoped<IFluxoDiarioService, FluxoDiarioService>();
            services.AddScoped<ILancamentoFactory, DefaultLancamentoFactory>();
        }

        private static void SetupRelatoriosContext(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioService, RelatorioService>();
        }
    }
}
