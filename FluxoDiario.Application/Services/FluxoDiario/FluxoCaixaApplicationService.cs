using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Repositories.FluxoDiario;
using FluxoDiario.Shared.Results.FluxoDiario;
using FluxoDiario.Shared.Logs;
using Serilog;

namespace FluxoDiario.Application.Services.FluxoDiario
{
    public class FluxoDiarioApplicationService : IFluxoDiarioApplicationService
    {
        protected readonly ICaixaReadRepository _caixaRepository;
        protected readonly ILogger _logger;

        public FluxoDiarioApplicationService(ICaixaReadRepository caixaRepository, ILogger logger)
        {
            _caixaRepository = caixaRepository;
            _logger = logger;
        }

        public async Task<Result<Caixa>> ObterCaixaObrigatoriaAsync(int caixaId, CancellationToken ct = default)
        {
            const string nomeMetodo = nameof(ObterCaixaObrigatoriaAsync);
            var resultadoConsulta = await _caixaRepository.ConsultarAsync(caixaId, ct);

            if (resultadoConsulta.IsFailed)
            {
                _logger.Error($"{LogVariables.ClassAndMethodName} Ocorreu um erro ao consultar o caixa informado. " +
                    $"Erro: {LogVariables.ErrorResult} | Id Caixa: {LogVariables.CaixaId}",
                    nameof(FluxoDiarioApplicationService), nomeMetodo, resultadoConsulta.Errors.FirstOrDefault(), caixaId);

                return new ErroConsultaCaixaResult("Ocorreu um erro ao consultar o caixa informado.");
            }

            if(resultadoConsulta.ValueOrDefault == null)
            {
                _logger.Warning($"{LogVariables.ClassAndMethodName} Caixa não encontrada. Id Caixa: {LogVariables.CaixaId}",
                    nameof(FluxoDiarioApplicationService), "ObterCaixa", caixaId);

                return new CaixaNaoEncontradaResult($"Não foi possível encontrar a caixa solicitada. Id informado: {caixaId}");
            }

            return resultadoConsulta;
        }
    }
}
