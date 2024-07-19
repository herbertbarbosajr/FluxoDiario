﻿using FluentResults;
using FluxoDiario.Domain.Builder.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Repositories.Relatorios;

namespace FluxoDiario.Domain.Providers.Relatorios
{
    public class DefaultLancamentoProvider : ILancamentoProvider
    {
        protected readonly IRelatorioBuilder _relatorioBuilder;
        protected readonly IRelatorioReadRepository _relatorioReadRepository;

        public DefaultLancamentoProvider(IRelatorioBuilder relatorioBuilder, IRelatorioReadRepository relatorioReadRepository)
        {
            _relatorioBuilder = relatorioBuilder;
            _relatorioReadRepository = relatorioReadRepository;
        }

        public async Task<Result> ExecutarAsync(Relatorio relatorio, CancellationToken ct = default)
        {
            var queryLancamentos = _relatorioReadRepository.BuscarQueryLancamentosParaRelatorio(relatorio);

            int numeroLancamentos = 0;

            foreach (var lancamento in queryLancamentos)
            {
                _relatorioBuilder.AdicionarLancamento(lancamento);
                numeroLancamentos++;
            }

            if (numeroLancamentos == 0)
                relatorio.Caixa.SaldoFinal = await _relatorioReadRepository.BuscarUltimoSaldoRegistradoAsync(relatorio, ct);

            return Result.Ok();
        }
    }
}
