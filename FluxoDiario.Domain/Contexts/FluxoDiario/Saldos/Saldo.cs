using FluentResults;
using FluxoDiario.Domain.Contexts.FluxoDiario.Eventos;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;

namespace FluxoDiario.Domain.Contexts.FluxoDiario.Saldos
{
    public class Saldo
    {
        protected readonly Caixa _caixa;

        protected Saldo() { }

        public Saldo(double valor, Caixa caixa)
        {
            Valor = valor;
            _caixa = caixa;
        }

        public double Valor { get; protected set; }

        public virtual Result<NovoLancamento> Contabilizar(ILancamento lancamento)
        {
            var resultadoLancamento = lancamento.Lancar(Valor);
            if (resultadoLancamento.IsFailed)
                return resultadoLancamento.ToResult();

            var eventoLancamento = new NovoLancamento(Valor, resultadoLancamento.Value, _caixa.Id, lancamento.Id);

            AtualizarSaldo(resultadoLancamento.Value);

            return eventoLancamento;
        }

        protected void AtualizarSaldo(double novoSaldo) => Valor = novoSaldo;
    }
}
