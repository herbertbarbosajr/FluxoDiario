using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoDiario.Domain.Factories.FluxoDiario.Interfaces
{
    public interface ILancamentoFactory
    {
        ILancamento Criar(TipoLancamento tipo, string descricao, double valor, DateTime? dataLancamento = null, int? id = null);
    }
}
