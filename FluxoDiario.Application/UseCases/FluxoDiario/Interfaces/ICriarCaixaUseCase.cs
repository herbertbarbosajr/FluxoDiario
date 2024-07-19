using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario;

namespace FluxoDiario.Application.UseCases.FluxoDiario.Interfaces
{
    public interface ICriarCaixaUseCase : IUseCase<CriarCaixaDto, Caixa>
    {
    }
}
