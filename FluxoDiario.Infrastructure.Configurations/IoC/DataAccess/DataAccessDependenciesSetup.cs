using FluxoDiario.DataAccess.Contexts;
using FluxoDiario.DataAccess.Mappers;
using FluxoDiario.DataAccess.Mappers.FluxoDiario;
using FluxoDiario.DataAccess.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.DataAccess.Mappers.Relatorios;
using FluxoDiario.DataAccess.Mappers.Relatorios.Interfaces;
using FluxoDiario.DataAccess.Models;
using FluxoDiario.DataAccess.Repositories.FluxoDiario;
using FluxoDiario.DataAccess.Repositories.Relatorios;
using FluxoDiario.Domain.Contexts.FluxoDiario.Eventos;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Repositories.FluxoDiario;
using FluxoDiario.Domain.Repositories.Relatorios;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDiario.Infrastructure.Configurations.IoC.DataAccess
{
    public static class DataAccessDependenciesSetup
    {
        public static IServiceCollection SetupDataAccess(this IServiceCollection services)
        {
            services.SetupFluxoDiarioContext();
            services.SetupRelatorioContext();

            return services;
        }

        private static void SetupFluxoDiarioContext(this IServiceCollection services)
        {
            services.AddScoped<FluxoDiario.DataAccess.Mappers.FluxoDiario.Interfaces.ICaixaDataMapper, FluxoDiario.DataAccess.Mappers.FluxoDiario.CaixaDataMapper>();
            services.AddScoped<IDefaultDataModelMapper<LancamentoDataModel, ILancamento>, LancamentoDataMapper>();
            services.AddScoped<IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento>, NovoLancamentoDataMapper>();

            services.AddScoped<ICaixaReadRepository, CaixaRepository>();
            services.AddScoped<ICaixaWriteRepository, CaixaRepository>();
        }

        private static void SetupRelatorioContext(this IServiceCollection services)
        {
            services.AddScoped<FluxoDiario.DataAccess.Mappers.Relatorios.Interfaces.ICaixaDataMapper, FluxoDiario.DataAccess.Mappers.Relatorios.CaixaDataMapper>();
            services.AddScoped<IRelatorioDataMapper, RelatorioDataMapper>();

            services.AddScoped<IRelatorioReadRepository, RelatorioRepository>();
            services.AddScoped<IRelatorioWriteRepository, RelatorioRepository>();
        }
    }
}
