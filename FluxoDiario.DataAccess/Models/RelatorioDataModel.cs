using FluxoDiario.DataAccess.Models.Interfaces;
using FluxoDiario.Domain.Contexts.Relatorios.Tipos;

namespace FluxoDiario.DataAccess.Models
{
    public class RelatorioDataModel : IDataModel<int>, IDateInfoDataModel
    {
        public int Id { get; set; }
        public int IdCaixa { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public DateOnly Data { get; set; }
        public TipoRelatorio Tipo { get; set; }
        public StatusRelatorio Status { get; set; }
        public string? CaminhoArquivo { get; set; }

        public CaixaDataModel Caixa { get; set; }
    }
}
