using FluentResults;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Caixas;
using FluxoDiario.Domain.Contexts.Relatorios.Lancamentos;

namespace FluxoDiario.Domain.Repositories.Relatorios
{
    public interface IRelatorioReadRepository
    {
        Task<Result> VerificarCaixaExisteAsync(int idCaixa, CancellationToken ct = default);
        Task<Result<Relatorio>> BuscarRelatorioComCaixaAsync(int id, CancellationToken ct = default);
        Task<Result<Relatorio>> BuscarRelatorioAsync(int id, CancellationToken ct = default);
        IQueryable<Lancamento> BuscarQueryLancamentosParaRelatorio(Relatorio relatorio);
        Task<double> BuscarUltimoSaldoRegistradoAsync(Relatorio relatorio, CancellationToken ct = default);
    }
}
