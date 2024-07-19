using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Eventos;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;

namespace FluxoDiario.Domain.Repositories.FluxoDiario
{
    public interface ICaixaWriteRepository
    {
        Task<Result<Caixa>> CriarCaixaAsync(Caixa caixa, CancellationToken ct = default);
        Task<Result<int>> AdicionarLancamentoAsync(int caixaId, ILancamento lancamento, NovoLancamento eventoLancamento, CancellationToken ct = default);
    }
}
