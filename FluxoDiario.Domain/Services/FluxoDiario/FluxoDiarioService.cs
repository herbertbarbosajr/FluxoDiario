using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Events;
using FluxoDiario.Domain.Events.FluxoDiario;
using FluxoDiario.Domain.Repositories.FluxoDiario;
using FluxoDiario.Domain.Results;
using FluxoDiario.Shared.Logs;
using FluxoDiario.Shared.Results.FluxoDiario;
using Serilog;

namespace FluxoDiario.Domain.Services.FluxoDiario
{
    public class FluxoDiarioService : IFluxoDiarioService
    {
        private readonly ILogger _logger;
        private readonly ICaixaWriteRepository _caixaWriteRepository;
        private readonly IEventPublisher _eventPublisher;

        public FluxoDiarioService(ILogger logger, ICaixaWriteRepository caixaWriteRepository, IEventPublisher eventPublisher)
        {
            _logger = logger;
            _caixaWriteRepository = caixaWriteRepository;
            _eventPublisher = eventPublisher;
        }

        public async Task<Result<Caixa>> CriarCaixaAsync(Caixa caixa, CancellationToken ct = default)
        {
            var createResult = await _caixaWriteRepository.CriarCaixaAsync(caixa);
            if(createResult.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Ocorreu um erro na criação do caixa. Erro: {LogVariables.ErrorResult}", 
                    nameof(FluxoDiarioService), nameof(CriarCaixaAsync), createResult.Errors.FirstOrDefault());
                return new ErroCriacaoCaixaResult($"Ocorreu um erro na criação do caixa.");
            }

            caixa = createResult.Value;

            await _eventPublisher.PublishAsync(new CaixaCriada(caixa.Id));

            return caixa;
        }

        public async Task<Result<Caixa>> ComputarLancamentoAsync(Caixa caixa, ILancamento lancamento, CancellationToken ct = default)
        {
            var resultadoEventoLancamentoCaixa = caixa.AdicionarLancamento(lancamento);

            if(resultadoEventoLancamentoCaixa.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Ocorreu um erro ao computar o lançamento. Id Caixa: {LogVariables.CaixaId}",
                    nameof(FluxoDiarioService), nameof(ComputarLancamentoAsync), caixa.Id);

                return new LancamentoInvalidoResult(resultadoEventoLancamentoCaixa.GetFirstErrorMessage() ?? "Lançamento inválido.");
            }

            var resultadoCriacao = await _caixaWriteRepository.AdicionarLancamentoAsync(
                caixa.Id, lancamento, resultadoEventoLancamentoCaixa.Value, ct);

            if(resultadoCriacao.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Ocorreu um erro ao salvar o lançamento. Id Caixa: {LogVariables.CaixaId}",
                    nameof(FluxoDiarioService), nameof(ComputarLancamentoAsync), caixa.Id);

                return new ErroCriacaoLevantamentoResult(resultadoCriacao.GetFirstErrorMessage() ?? "Erro ao salvar lançamento.");
            }

            lancamento.Criado(resultadoCriacao.Value);
            await _eventPublisher.PublishAsync(new LancamentoCriado(caixa.Id, lancamento.Id));

            return caixa;
        }
    }
}
