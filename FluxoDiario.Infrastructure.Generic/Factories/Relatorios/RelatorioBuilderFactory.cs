using FluxoDiario.Domain.Builder.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Tipos;
using FluxoDiario.Domain.Factories.Relatorios.Builders;
using FluxoDiario.Infrastructure.Generic.Builders.Relatorios;
using FluxoDiario.Infrastructure.Generic.Files;

namespace FluxoDiario.Infrastructure.Generic.Factories.Relatorios
{
    public class RelatorioBuilderFactory : IRelatorioBuilderFactory
    {
        private readonly IFileWriter _fileWriter;

        public RelatorioBuilderFactory(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public IRelatorioBuilder CriarBuilder(Relatorio relatorio)
        {
            switch(relatorio.Tipo)
            {
                case TipoRelatorio.JSON:
                    var builder = new JsonRelatorioBuilder(_fileWriter);
                    builder.SetRelatorio(relatorio);
                    return builder;
            }

            throw new NotImplementedException("Tipo de relatório não implementado.");
        }
    }
}
