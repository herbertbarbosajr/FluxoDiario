using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Caixas;

namespace FluxoDiario.DataAccess.Mappers.Relatorios.Interfaces
{
    public interface IRelatorioDataMapper
    {
        Relatorio ToEntity(RelatorioDataModel model, Caixa caixa = null);
        RelatorioDataModel ToModel(Relatorio relatorio, int idCaixa);
        void UpdateData(Relatorio relatorio, RelatorioDataModel model);
    }
}
