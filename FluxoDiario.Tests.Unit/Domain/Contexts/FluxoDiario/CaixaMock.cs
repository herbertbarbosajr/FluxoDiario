using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Saldos;

namespace FluxoDiario.Tests.Unit.Domain.Contexts.FluxoDiario
{
    public class CaixaMock : Caixa
    {
        public CaixaMock(string nome, double saldoInicial = 0) : base(nome, saldoInicial)
        {
        }

        public void SetSaldo(Saldo saldo) => Saldo = saldo;
        public void SetId(int id) => Id = id;
    }
}
