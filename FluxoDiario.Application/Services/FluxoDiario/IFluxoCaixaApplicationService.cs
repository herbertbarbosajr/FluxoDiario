using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario;

namespace FluxoDiario.Application.Services.FluxoDiario
{
    public interface IFluxoDiarioApplicationService
    {
        Task<Result<Caixa>> ObterCaixaObrigatoriaAsync(int caixaId, CancellationToken ct = default);
    }
}
