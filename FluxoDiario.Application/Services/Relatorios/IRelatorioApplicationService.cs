using FluentResults;

namespace FluxoDiario.Application.Services.Relatorios
{
    public interface IRelatorioApplicationService
    {
        Task<Result> IniciarGeracaoRelatorioAsync(int idRelatorio, CancellationToken cancellationToken = default);
    }
}
