using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;

namespace FluxoDiario.Application.Mappers.FluxoDiario.Interfaces
{
    public interface ILancamentoApplicationMapper
    {
        ILancamento MapearLancamento(AdicionarLancamentoDto dto);
    }
}
