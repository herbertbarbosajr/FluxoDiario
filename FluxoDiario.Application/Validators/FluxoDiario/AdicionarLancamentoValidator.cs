﻿using FluentResults;
using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Shared.Extensions;

namespace FluxoDiario.Application.Validators.FluxoDiario
{
    public class AdicionarLancamentoValidator : BaseValidator<AdicionarLancamentoDto>
    {
        public override Result Validar(AdicionarLancamentoDto value)
        {
            var errorMessages = new List<string>();

            if (value.IdCaixa.IsNullOrLessThanZero())
                errorMessages.Add("Id do Caixa é obrigatório.");

            if (value.TipoLancamento == null)
                errorMessages.Add("Tipo de Lançamento é obrigatório.");

            if (string.IsNullOrWhiteSpace(value.Descricao))
                errorMessages.Add("Descrição é obrigatória.");

            if (value.Valor.IsNullOrLessThanZero())
                errorMessages.Add("Valor deve ser maior que zero.");

            return obterResultado(errorMessages);
        }
    }
}
