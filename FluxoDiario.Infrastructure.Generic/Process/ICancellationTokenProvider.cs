namespace FluxoDiario.Infrastructure.Generic.Process
{
    public interface ICancellationTokenProvider
    {
        CancellationToken CancellationToken { get; }
    }
}
