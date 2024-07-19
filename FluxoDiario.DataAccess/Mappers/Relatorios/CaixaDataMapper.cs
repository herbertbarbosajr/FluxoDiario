using FluxoDiario.DataAccess.Mappers.Relatorios.Interfaces;
using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.Relatorios.Caixas;

namespace FluxoDiario.DataAccess.Mappers.Relatorios
{
    public class CaixaDataMapper : ICaixaDataMapper
    {
        public Caixa ToEntity(CaixaDataModel model)
        {
            return new Caixa(model.Id, model.Nome);
        }
    }
}
