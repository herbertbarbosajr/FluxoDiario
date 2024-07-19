using FluentResults;
using FluxoDiario.Shared.Results;

namespace FluxoDiario.Domain.Results
{
    public class ValidationErrorResult : BaseErrorResult
    {
        public ValidationErrorResult(string message) : base(message)
        {
        }

        public ValidationErrorResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
