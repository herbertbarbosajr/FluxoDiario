using FluentResults;

namespace FluxoDiario.Shared.Results.FluxoDiario
{
    public class ErroCriacaoCaixaResult : BaseErrorResult
    {
        public ErroCriacaoCaixaResult(string message) : base(message)
        {
        }

        public ErroCriacaoCaixaResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
