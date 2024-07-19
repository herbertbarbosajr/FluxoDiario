using FluxoDiario.DataAccess.Models;
using FluxoDiario.Domain.Contexts.FluxoDiario.Eventos;

namespace FluxoDiario.DataAccess.Mappers.FluxoDiario
{
    public class NovoLancamentoDataMapper : IDefaultDataModelMapper<NovoLancamentoDataModel, NovoLancamento>
    {
        public NovoLancamento ToEntity(NovoLancamentoDataModel model)
        {
            return new NovoLancamento(model.SaldoAnterior, model.SaldoAtual, model.CaixaId, model.LancamentoId);
        }

        public NovoLancamentoDataModel ToModel(NovoLancamento entity)
        {
            return new NovoLancamentoDataModel()
            {
                SaldoAtual = entity.SaldoAtual,
                SaldoAnterior = entity.SaldoAnterior,
                CaixaId = entity.CaixaId,
                LancamentoId = entity.LancamentoId
            };
        }
    }
}
