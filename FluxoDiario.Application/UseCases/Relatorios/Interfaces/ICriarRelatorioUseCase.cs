using FluxoDiario.Application.Dtos.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios;

namespace FluxoDiario.Application.UseCases.Relatorios.Interfaces
{
    public interface ICriarRelatorioUseCase : IUseCase<CriarRelatorioDto, Relatorio>
    {
    }
}
