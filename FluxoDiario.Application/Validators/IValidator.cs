using FluentResults;

namespace FluxoDiario.Application.Validators
{
    public interface IValidator<T>
    {
        Result Validar(T value);
    }
}
