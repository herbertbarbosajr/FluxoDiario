using FluentResults;

namespace FluxoDiario.Shared.Results.FluxoDiario
{
    public class ErroConsultaCaixaResult : BaseErrorResult
    {
        public ErroConsultaCaixaResult(string message) : base(message)
        {
        }

        public ErroConsultaCaixaResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
