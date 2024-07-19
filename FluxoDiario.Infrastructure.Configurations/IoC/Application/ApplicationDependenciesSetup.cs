using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Application.Dtos.Relatorios;
using FluxoDiario.Application.Mappers.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Application.Mappers.Relatorios;
using FluxoDiario.Application.Mappers.Relatorios.Interfaces;
using FluxoDiario.Application.Services.FluxoDiario;
using FluxoDiario.Application.Services.Relatorios;
using FluxoDiario.Application.UseCases.FluxoDiario;
using FluxoDiario.Application.UseCases.FluxoDiario.Interfaces;
using FluxoDiario.Application.UseCases.Relatorios;
using FluxoDiario.Application.UseCases.Relatorios.Interfaces;
using FluxoDiario.Application.Validators;
using FluxoDiario.Application.Validators.FluxoDiario;
using FluxoDiario.Application.Validators.Relatorios;
using FluxoDiario.Domain.Factories.Relatorios.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDiario.Infrastructure.Configurations.IoC.Application
{
    public static class ApplicationDependenciesSetup
    {
        public static IServiceCollection SetupApplication(this IServiceCollection services)
        {
            services.SetupFluxoDiarioContext();
            services.SetupRelatoriosContext();
            
            return services;
        }

        private static void SetupFluxoDiarioContext(this IServiceCollection services)
        {
            services.AddScoped<ICaixaApplicationMapper, CaixaApplicationMapper>();
            services.AddScoped<ILancamentoApplicationMapper, LancamentoApplicationMapper>();

            services.AddScoped<IFluxoDiarioApplicationService, FluxoDiarioApplicationService>();

            services.AddScoped<IAdicionarLancamentoUseCase, AdicionarLancamentoUseCase>();
            services.AddScoped<ICriarCaixaUseCase, CriarCaixaUseCase>();
            services.AddScoped<IConsultarSaldoUseCase, ConsultarSaldoUseCase>();

            services.AddScoped<IValidator<AdicionarLancamentoDto>, AdicionarLancamentoValidator>();
            services.AddScoped<IValidator<CriarCaixaDto>, CriarCaixaValidator>();
        }

        private static void SetupRelatoriosContext(this IServiceCollection services)
        {
            services.AddScoped<IRelatorioApplicationMapper, RelatorioApplicationMapper>();

            services.AddScoped<IRelatorioApplicationService, RelatorioApplicationService>();

            services.AddScoped<ICriarRelatorioUseCase, CriarRelatorioUseCase>();
            services.AddScoped<IDownloadRelatorioUseCase, DownloadRelatorioUseCase>();
            services.AddScoped<IConsultarStatusRelatorioUseCase, ConsultarStatusRelatorioUseCase>();

            services.AddScoped<IValidator<CriarRelatorioDto>, CriarRelatorioValidator>();

            services.AddScoped<ILancamentoProviderFactory, LancamentoProviderFactory>();

        }
    }
}
