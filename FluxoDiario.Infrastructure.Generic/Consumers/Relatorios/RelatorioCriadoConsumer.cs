using FluxoDiario.Application.Services.Relatorios;
using FluxoDiario.Domain.Events.Relatorios;
using FluxoDiario.Infrastructure.Generic.Process;
using FluxoDiario.Shared.Logs;
using MassTransit;
using Serilog;

namespace FluxoDiario.Infrastructure.Generic.Consumers.Relatorios
{
    public class RelatorioCriadoConsumer : IConsumer<RelatorioCriado>
    {
        private readonly ILogger _logger;
        private readonly IRelatorioApplicationService _relatorioService;
        private readonly ICancellationTokenProvider _cancellationTokenProvider;

        public RelatorioCriadoConsumer(ILogger logger, IRelatorioApplicationService relatorioService, ICancellationTokenProvider cancellationTokenProvider)
        {
            _logger = logger;
            _relatorioService = relatorioService;
            _cancellationTokenProvider = cancellationTokenProvider;
        }

        public async Task Consume(ConsumeContext<RelatorioCriado> context)
        {
            var relatorioId = context.Message.Id;

            if(relatorioId <= 0)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Id Relatorio vazio.", nameof(RelatorioCriadoConsumer), nameof(Consume));
                return;
            }

            _logger.Information($"{LogVariables.ClassAndMethodName} Iniciando processamento do relatório {LogVariables.RelatorioId}",
                nameof(RelatorioCriadoConsumer), nameof(Consume), relatorioId);

            await _relatorioService.IniciarGeracaoRelatorioAsync(relatorioId, _cancellationTokenProvider.CancellationToken);

            _logger.Information($"{LogVariables.ClassAndMethodName} Finalizando processamento do relatório {LogVariables.RelatorioId}",
                nameof(RelatorioCriadoConsumer), nameof(Consume), relatorioId);
        }
    }
}
