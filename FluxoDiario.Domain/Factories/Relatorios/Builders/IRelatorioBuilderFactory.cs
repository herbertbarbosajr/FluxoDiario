using FluxoDiario.Domain.Builder.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios;

namespace FluxoDiario.Domain.Factories.Relatorios.Builders
{
    public interface IRelatorioBuilderFactory
    {
        IRelatorioBuilder CriarBuilder(Relatorio relatorio);
    }
}
