using FluentResults;

namespace FluxoDiario.Shared.Results.FluxoDiario
{
    public class ErroCriacaoLevantamentoResult : BaseErrorResult
    {
        public ErroCriacaoLevantamentoResult(string message) : base(message)
        {
        }

        public ErroCriacaoLevantamentoResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
