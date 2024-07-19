using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Domain.Contexts.FluxoDiario.Lancamentos;
using FluxoDiario.Domain.Factories.FluxoDiario.Interfaces;

namespace FluxoDiario.Application.Mappers.FluxoDiario
{
    public class LancamentoApplicationMapper : ILancamentoApplicationMapper
    {
        protected readonly ILancamentoFactory _factory;

        public LancamentoApplicationMapper(ILancamentoFactory factory)
        {
            _factory = factory;
        }

        public ILancamento MapearLancamento(AdicionarLancamentoDto dto)
        {
            return _factory.Criar(dto.TipoLancamento.Value, dto.Descricao, dto.Valor.Value, dto.DataLancamento);
        }
    }
}
