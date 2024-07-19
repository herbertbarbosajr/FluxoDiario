using FluentResults;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Lancamentos;

namespace FluxoDiario.Domain.Builder.Relatorios
{
    public interface IRelatorioBuilder
    {
        void SetRelatorio(Relatorio relatorio);
        void AdicionarLancamento(Lancamento lancamento);
        Task<Result<string>> EscreverRelatorioAsync(CancellationToken ct = default);
    }
}
