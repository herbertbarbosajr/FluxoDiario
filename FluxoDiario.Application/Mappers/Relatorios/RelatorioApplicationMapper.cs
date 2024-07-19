using FluxoDiario.Application.Dtos.Relatorios;
using FluxoDiario.Application.Mappers.Relatorios.Interfaces;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Tipos;

namespace FluxoDiario.Application.Mappers.Relatorios
{
    public class RelatorioApplicationMapper : IRelatorioApplicationMapper
    {
        public Relatorio MapearNovoRelatorio(CriarRelatorioDto dto, StatusRelatorio statusInicial)
        {
            return new Relatorio(dto.Data.Value, dto.TipoRelatorio.Value, statusInicial);
        }
    }
}
