using FluxoDiario.Presentation.API.Mappers.FluxoDiario;
using FluxoDiario.Presentation.API.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Presentation.API.Mappers.Relatorios;
using FluxoDiario.Presentation.API.Mappers.Relatorios.Interfaces;

namespace FluxoDiario.Presentation.API.Setup.IoC
{
    public static class APIDependenciesSetup
    {
        public static IServiceCollection SetupAPI(this IServiceCollection services)
        {
            services.AddScoped<ICaixaPresentationMapper, CaixaPresentationMapper>();
            services.AddScoped<IRelatorioPresentationMapper, RelatorioPresentationMapper>();

            return services;
        }
    }
}
