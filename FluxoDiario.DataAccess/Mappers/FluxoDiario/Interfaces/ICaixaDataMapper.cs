using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.FluxoDiario;

namespace FluxoDiario.DataAccess.Mappers.FluxoDiario.Interfaces
{
    public interface ICaixaDataMapper
    {
        Caixa ToEntity(CaixaDataModel model, double saldoAtual);
        CaixaDataModel ToModel(Caixa caixa);
    }
}
