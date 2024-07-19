using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario;

namespace FluxoDiario.Domain.Repositories.FluxoDiario
{
    public interface ICaixaReadRepository
    {
        Task<Result<Caixa>> ConsultarAsync(int id, CancellationToken ct = default);
    }
}
