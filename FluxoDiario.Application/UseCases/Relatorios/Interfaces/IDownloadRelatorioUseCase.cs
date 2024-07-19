using FluxoDiario.Application.Dtos;

namespace FluxoDiario.Application.UseCases.Relatorios.Interfaces
{
    public interface IDownloadRelatorioUseCase : IUseCase<int, FileDto>
    {
    }
}
