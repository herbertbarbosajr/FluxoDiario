using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.Relatorios.Caixas;

namespace FluxoDiario.DataAccess.Mappers.Relatorios.Interfaces
{
    public interface ICaixaDataMapper
    {
        Caixa ToEntity(CaixaDataModel model);
    }
}
