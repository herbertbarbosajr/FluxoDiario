using FluentResults;

namespace FluxoDiario.Shared.Results.FluxoDiario
{
    public class LancamentoInvalidoResult : BaseErrorResult
    {
        public LancamentoInvalidoResult(string message) : base(message)
        {
        }

        public LancamentoInvalidoResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
