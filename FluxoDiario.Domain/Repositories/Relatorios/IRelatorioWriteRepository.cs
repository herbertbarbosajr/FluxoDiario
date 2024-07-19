using FluentResults;
using FluxoDiario.Domain.Contexts.Relatorios;

namespace FluxoDiario.Domain.Repositories.Relatorios
{
    public interface IRelatorioWriteRepository
    {
        Task<Result<Relatorio>> CriarRelatorioAsync(Relatorio relatorio, int idCaixa, CancellationToken ct = default);
        Task<Result> AtualizarRelatorioAsync(Relatorio relatorio, CancellationToken ct = default);
    }
}
