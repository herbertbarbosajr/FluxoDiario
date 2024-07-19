using FluentResults;

namespace FluxoDiario.Shared.Results.FluxoDiario
{
    public class CaixaNaoEncontradaResult : BaseErrorResult
    {
        public CaixaNaoEncontradaResult(string message) : base(message)
        {
        }

        public CaixaNaoEncontradaResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
