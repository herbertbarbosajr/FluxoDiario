namespace FluxoDiario.Domain.Events.FluxoDiario
{
    public class CaixaCriada : IEvent
    {
        public CaixaCriada(int caixaId)
        {
            CaixaId = caixaId;
        }

        public int CaixaId { get; }
    }
}
