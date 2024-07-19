using FluxoDiario.Domain.Events.FluxoDiario;
using FluxoDiario.Infrastructure.Generic.Consumers.Relatorios;
using MassTransit;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDiario.Infrastructure.Configurations.MessageQueue
{
    public static class RabbitMqConfigurations
    {
        public static IServiceCollection ConfigureRabbitMq(this IServiceCollection services, RabbitMqConfigurationType configType)
        {
            services.AddMassTransit(x =>
            {
                if (configType == RabbitMqConfigurationType.Consumer)
                    x.ConfigureConsumers();

                x.UsingRabbitMq((context, config) =>
                {
                    config.Host(RabbitMqConfigurationProvider.HostName, "/", host =>
                    {
                        host.Username(RabbitMqConfigurationProvider.User);
                        host.Password(RabbitMqConfigurationProvider.Password);
                    });

                    config.ConfigureEndpoints(context);
                });
            });

            return services;
        }

        private static void ConfigureConsumers(this IBusRegistrationConfigurator config)
        {
            config.AddConsumer<RelatorioCriadoConsumer>().Endpoint(e =>
            {
                if (e is IRabbitMqReceiveEndpointConfigurator r)
                {
                    r.Durable = true;
                    r.AutoDelete = false;
                }
            });
        }
    }
}
