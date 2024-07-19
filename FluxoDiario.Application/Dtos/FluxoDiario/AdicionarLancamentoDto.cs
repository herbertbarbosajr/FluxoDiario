using FluxoDiario.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoDiario.Application.Dtos.FluxoDiario
{
    public class AdicionarLancamentoDto
    {
        public int? IdCaixa { get; set; }
        public double? Valor { get; set; }
        public string? Descricao { get; set; }
        public TipoLancamento? TipoLancamento { get; set; }
        public DateTime? DataLancamento { get; set; }
    }
}
