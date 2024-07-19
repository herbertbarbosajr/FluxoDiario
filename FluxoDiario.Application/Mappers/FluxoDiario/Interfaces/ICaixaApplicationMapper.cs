using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario;

namespace FluxoDiario.Application.Mappers.FluxoDiario.Interfaces
{
    public interface ICaixaApplicationMapper
    {
        Caixa MapearCaixa(CriarCaixaDto caixaDto);
        ConsultarSaldoDto MapearConsultaSaldo(Caixa caixa);
    }
}
