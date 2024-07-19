using FluentResults;
using FluxoDiario.Domain.Contexts.Relatorios;

namespace FluxoDiario.Domain.Providers.Relatorios
{
    public interface ILancamentoProvider
    {
        Task<Result> ExecutarAsync(Relatorio relatorio, CancellationToken ct = default);
    }
}
