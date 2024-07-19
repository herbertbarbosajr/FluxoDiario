using FluxoDiario.Domain.Builder.Relatorios;
using FluxoDiario.Domain.Providers.Relatorios;
using FluxoDiario.Domain.Repositories.Relatorios;

namespace FluxoDiario.Domain.Factories.Relatorios.Providers
{
    public class LancamentoProviderFactory : ILancamentoProviderFactory
    {
        private readonly IRelatorioReadRepository _repository;

        public LancamentoProviderFactory(IRelatorioReadRepository repository)
        { 
            _repository = repository;
        }

        public ILancamentoProvider CriarProvider(IRelatorioBuilder relatorioBuilder)
        {
            return new DefaultLancamentoProvider(relatorioBuilder, _repository);
        }
    }
}
