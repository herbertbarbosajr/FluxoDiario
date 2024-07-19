﻿namespace FluxoDiario.Domain.Events.FluxoDiario
{
    public class LancamentoCriado : IEvent
    {
        public LancamentoCriado(int caixaId, int lancamentoId)
        {
            CaixaId = caixaId;
            LancamentoId = lancamentoId;
        }

        public int CaixaId { get; }
        public int LancamentoId { get; }
    }
}
