using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;

namespace FluxoDiario.Domain.Services.FluxoDiario
{
    public interface IFluxoDiarioService
    {
        Task<Result<Caixa>> CriarCaixaAsync(Caixa caixa, CancellationToken ct = default);
        Task<Result<Caixa>> ComputarLancamentoAsync(Caixa caixa, ILancamento lancamento, CancellationToken ct = default);
    }
}
