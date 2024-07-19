﻿using FluentResults;

namespace FluxoDiario.Shared.Results.Relatorios
{
    public class RelatorioNaoEncontradoResult : BaseErrorResult
    {
        public RelatorioNaoEncontradoResult(string message) : base(message)
        {
        }

        public RelatorioNaoEncontradoResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
