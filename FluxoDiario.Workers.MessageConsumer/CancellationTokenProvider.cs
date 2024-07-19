using FluxoDiario.Infrastructure.Generic.Process;

namespace FluxoDiario.Workers.MessageConsumer
{
    public class CancellationTokenProvider : ICancellationTokenProvider
    {
        public CancellationToken CancellationToken { get; set; } = default;
    }
}
