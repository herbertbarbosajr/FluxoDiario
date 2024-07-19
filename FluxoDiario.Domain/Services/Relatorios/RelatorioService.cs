using FluentResults;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Caixas;
using FluxoDiario.Domain.Events;
using FluxoDiario.Domain.Events.Relatorios;
using FluxoDiario.Domain.Factories.Relatorios.Builders;
using FluxoDiario.Domain.Factories.Relatorios.Providers;
using FluxoDiario.Domain.Repositories.Relatorios;
using FluxoDiario.Shared.Logs;
using FluxoDiario.Shared.Results.Relatorios;
using Serilog;

namespace FluxoDiario.Domain.Services.Relatorios
{
    public class RelatorioService : IRelatorioService
    {
        protected readonly ILogger _logger;
        protected readonly IEventPublisher _eventPublisher;
        protected readonly IRelatorioWriteRepository _relatorioWriteRepository;
        protected readonly IRelatorioBuilderFactory _relatorioBuilderFactory;
        protected readonly ILancamentoProviderFactory _lancamentoProviderFactory;

        public RelatorioService(ILogger logger, IEventPublisher eventPublisher, 
            IRelatorioWriteRepository relatorioWriteRepository, IRelatorioBuilderFactory relatorioBuilderFactory,
            ILancamentoProviderFactory lancamentoProviderFactory)
        {
            _logger = logger;
            _eventPublisher = eventPublisher;
            _relatorioWriteRepository = relatorioWriteRepository;
            _relatorioBuilderFactory = relatorioBuilderFactory;
            _lancamentoProviderFactory = lancamentoProviderFactory;
        }

        public async Task<Result<Relatorio>> CriarRelatorioAsync(Relatorio relatorio, int idCaixa, CancellationToken cancellationToken = default)
        {
            var resultadoCriacao = await _relatorioWriteRepository.CriarRelatorioAsync(relatorio, idCaixa, cancellationToken);

            if(resultadoCriacao.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Ocorreu um erro inesperado ao criar o registro do relatório.",
                    nameof(RelatorioService), nameof(CriarRelatorioAsync));

                return new ErroCriacaoRelatorioResult("Ocorreu um erro ao solicitar a criação do relatório");
            }

            await _eventPublisher.PublishAsync(new RelatorioCriado(resultadoCriacao.Value.Id));

            return resultadoCriacao;
        }

        public async Task<Result> GerarRelatorioAsync(Relatorio relatorio, CancellationToken cancellationToken = default)
        {
            relatorio.IniciarProcessamento();
            await _relatorioWriteRepository.AtualizarRelatorioAsync(relatorio, cancellationToken);

            var builder = _relatorioBuilderFactory.CriarBuilder(relatorio);
            var lancamentoProvider = _lancamentoProviderFactory.CriarProvider(builder);

            var lancamentoResult = await lancamentoProvider.ExecutarAsync(relatorio, cancellationToken);
            if(lancamentoResult.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Ocorreu um erro ao processar os lançamentos para gerar o relatório. Id do Relatório: {LogVariables.RelatorioId}",
                    nameof(RelatorioService), nameof(GerarRelatorioAsync), relatorio.Id);

                await FinalizarProcessamentoComErroAsync(relatorio, cancellationToken);
                return lancamentoResult;
            }

            var builderResult = await builder.EscreverRelatorioAsync(cancellationToken);
            if(builderResult.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Ocorreu um erro ao finalizar o processamento e escrita do relatório. Id do Relatório: {LogVariables.RelatorioId}",
                    nameof(RelatorioService), nameof(GerarRelatorioAsync), relatorio.Id);

                await FinalizarProcessamentoComErroAsync(relatorio, cancellationToken);
                return builderResult.ToResult();
            }

            relatorio.FinalizarProcessamento(builderResult.Value);
            await _relatorioWriteRepository.AtualizarRelatorioAsync(relatorio, cancellationToken);
            await _eventPublisher.PublishAsync(new RelatorioCriado(relatorio.Id));
            return Result.Ok();
        }

        protected async Task FinalizarProcessamentoComErroAsync(Relatorio relatorio, CancellationToken cancellationToken)
        {
            relatorio.ApontarErroProcessamento();
            await _relatorioWriteRepository.AtualizarRelatorioAsync(relatorio, cancellationToken);
        }
    }
}
