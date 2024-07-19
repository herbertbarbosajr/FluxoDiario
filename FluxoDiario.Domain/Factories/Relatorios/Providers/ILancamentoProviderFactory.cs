using FluxoDiario.Domain.Builder.Relatorios;
using FluxoDiario.Domain.Providers.Relatorios;

namespace FluxoDiario.Domain.Factories.Relatorios.Providers
{
    public interface ILancamentoProviderFactory
    {
        ILancamentoProvider CriarProvider(IRelatorioBuilder relatorioBuilder);
    }
}
