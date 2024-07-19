using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Factories.FluxoDiario.Interfaces;

namespace FluxoDiario.DataAccess.Mappers.FluxoDiario
{
    public class LancamentoDataMapper : IDefaultDataModelMapper<LancamentoDataModel, ILancamento>
    {
        protected readonly ILancamentoFactory _factory;

        public LancamentoDataMapper(ILancamentoFactory factory) 
        {
            _factory = factory;
        }

        public ILancamento ToEntity(LancamentoDataModel model)
        {
            return _factory.Criar(model.Tipo, model.Descricao, model.Valor, model.DataLancamento, model.Id);
        }

        public LancamentoDataModel ToModel(ILancamento entity)
        {
            return new LancamentoDataModel()
            {
                Id = entity.Id,
                Tipo = entity.Tipo,
                Descricao = entity.Descricao,
                Valor = entity.Valor,
                DataLancamento = entity.DataHora
            };
        }
    }
}
