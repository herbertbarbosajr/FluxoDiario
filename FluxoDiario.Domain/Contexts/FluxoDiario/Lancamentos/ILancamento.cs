using FluentResults;
using FluxoDiario.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos
{
    public interface ILancamento
    {
        int Id { get; }
        double Valor { get; }
        string Descricao { get; }
        TipoLancamento Tipo { get; }
        DateTime DataHora { get; }
        Result<double> Lancar(double saldoAtual);
        void Criado(int id);
    }
}
