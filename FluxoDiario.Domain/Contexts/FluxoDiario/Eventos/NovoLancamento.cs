namespace FluxoDiario.Domain.Contexts.FluxoDiario.Eventos
{
    public readonly record struct NovoLancamento(double SaldoAnterior, double SaldoAtual, int CaixaId, int LancamentoId);
}
