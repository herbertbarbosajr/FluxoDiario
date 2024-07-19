using FluxoDiario.DataAccess.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.FluxoDiario;

namespace FluxoDiario.DataAccess.Mappers.FluxoDiario
{
    public class CaixaDataMapper : ICaixaDataMapper
    {
        public Caixa ToEntity(CaixaDataModel model, double saldoAtual)
        {
            return new Caixa(model.Id, model.Nome, saldoAtual);
        }

        public CaixaDataModel ToModel(Caixa entity)
        {
            return new CaixaDataModel()
            {
                Id = entity.Id,
                Nome = entity.Nome
            };
        }
    }
}
