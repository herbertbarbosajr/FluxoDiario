using FluentResults;
using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Application.UseCases.FluxoDiario.Interfaces;
using FluxoDiario.Domain.Repositories.FluxoDiario;
using FluxoDiario.Domain.Results;
using FluxoDiario.Shared.Logs;
using FluxoDiario.Shared.Results.FluxoDiario;
using Serilog;

namespace FluxoDiario.Application.UseCases.FluxoDiario
{
    public class ConsultarSaldoUseCase : IConsultarSaldoUseCase
    {
        protected readonly ICaixaReadRepository _caixaReadRepository;
        protected readonly ICaixaApplicationMapper _mapper;
        protected readonly ILogger _logger;

        public ConsultarSaldoUseCase(ICaixaReadRepository caixaReadRepository, ICaixaApplicationMapper mapper, ILogger logger)
        {
            _caixaReadRepository = caixaReadRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Result<ConsultarSaldoDto>> ExecutarAsync(int input, CancellationToken ct = default)
        {
            var resultadoConsulta = await _caixaReadRepository.ConsultarAsync(input, ct);

            if (resultadoConsulta.IsFailed || resultadoConsulta.Value == null)
            {
                _logger.Warning($"{LogVariables.ClassAndMethodName} Caixa não encontrada.",
                    nameof(ConsultarSaldoUseCase), nameof(ExecutarAsync));
                return new CaixaNaoEncontradaResult(resultadoConsulta.GetFirstErrorMessage() ?? "Caixa não encontrada");
            }

            return _mapper.MapearConsultaSaldo(resultadoConsulta.Value);
        }
    }
}
