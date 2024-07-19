using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Domain.Contexts.FluxoDiario;

namespace FluxoDiario.Application.Mappers.FluxoDiario
{
    public class CaixaApplicationMapper : ICaixaApplicationMapper
    {
        public Caixa MapearCaixa(CriarCaixaDto caixaDto)
            => new Caixa(caixaDto.Nome);

        public ConsultarSaldoDto MapearConsultaSaldo(Caixa caixa)
        {
            return new ConsultarSaldoDto()
            {
                IdCaixa = caixa.Id,
                Saldo = caixa.Saldo.Valor
            };
        }
    }
}
