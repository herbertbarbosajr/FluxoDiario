using FluentResults;
using FluxoDiario.Domain.Contexts.Relatorios;

namespace FluxoDiario.Domain.Services.Relatorios
{
    public interface IRelatorioService
    {
        Task<Result<Relatorio>> CriarRelatorioAsync(Relatorio relatorio, int idCaixa, CancellationToken cancellationToken = default);

        Task<Result> GerarRelatorioAsync(Relatorio relatorio, CancellationToken cancellationToken = default);
    }
}
