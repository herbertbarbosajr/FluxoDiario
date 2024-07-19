using FluxoDiario.Application.Dtos.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Tipos;

namespace FluxoDiario.Application.Mappers.Relatorios.Interfaces
{
    public interface IRelatorioApplicationMapper
    {
        Relatorio MapearNovoRelatorio(CriarRelatorioDto dto, StatusRelatorio statusInicial);
    }
}
