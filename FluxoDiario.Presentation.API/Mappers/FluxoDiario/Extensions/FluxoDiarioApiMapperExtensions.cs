using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Contexts.SharedKernel.Tipos;
using FluxoDiario.Presentation.API.Models.FluxoDiario.Responses;

namespace FluxoDiario.Presentation.API.Mappers.FluxoDiario.Extensions
{
    public static class FluxoDiarioApiMapperExtensions
    {
        private static readonly Dictionary<TipoLancamento, string> _nomesTiposLancamento = new Dictionary<TipoLancamento, string>()
        {
            { TipoLancamento.Debito, "Débito" },
            { TipoLancamento.Credito, "Crédito"},
            { TipoLancamento.Nenhum, "Inválido"}
        };

        public static CaixaResponseModel ToResponseModel(this Caixa caixa)
        {
            return new CaixaResponseModel(caixa.Id, caixa.Nome, caixa?.Lancamentos.Select(x => x.ToResponseModel()), caixa.Saldo.Valor);
        }

        public static LancamentoResponseModel ToResponseModel(this ILancamento lancamento)
        {
            return new LancamentoResponseModel(lancamento.Id, lancamento.Valor, lancamento.Descricao,
                _nomesTiposLancamento[lancamento.Tipo], lancamento.DataHora.ToString("dd-MM-yyyy HH:mm:ss"));
        }

        public static ConsultarSaldoResponseModel ToResponseModel(this ConsultarSaldoDto dto)
        {
            return new ConsultarSaldoResponseModel(dto.IdCaixa, dto.Saldo);
        }
    }
}
