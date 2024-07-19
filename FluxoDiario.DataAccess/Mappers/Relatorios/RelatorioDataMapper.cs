using FluxoDiario.DataAccess.Mappers.Relatorios.Interfaces;
using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Caixas;

namespace FluxoDiario.DataAccess.Mappers.Relatorios
{
    public class RelatorioDataMapper : IRelatorioDataMapper
    {
        public Relatorio ToEntity(RelatorioDataModel model, Caixa caixa = null)
        {
            return new Relatorio(model.Id, model.Data, model.Tipo, model.Status, model.CaminhoArquivo, caixa);
        }

        public RelatorioDataModel ToModel(Relatorio relatorio, int idCaixa)
        {
            return new RelatorioDataModel()
            {
                Data = relatorio.Data,
                Tipo = relatorio.Tipo,
                Status = relatorio.Status,
                IdCaixa = idCaixa,
                CaminhoArquivo = relatorio.CaminhoArquivo
            };
        }

        public void UpdateData(Relatorio relatorio, RelatorioDataModel model)
        {
            model.Status = relatorio.Status;
            model.CaminhoArquivo = relatorio.CaminhoArquivo;
        }
    }
}
