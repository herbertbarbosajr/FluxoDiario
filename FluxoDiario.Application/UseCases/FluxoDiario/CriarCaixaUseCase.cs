using FluentResults;
using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Application.UseCases.FluxoDiario.Interfaces;
using FluxoDiario.Application.Validators;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Contexts.SharedKernel.Tipos;
using FluxoDiario.Domain.Factories.FluxoDiario.Interfaces;
using FluxoDiario.Domain.Services.FluxoDiario;

namespace FluxoDiario.Application.UseCases.FluxoDiario
{
    public class CriarCaixaUseCase : ICriarCaixaUseCase
    {
        protected readonly IFluxoDiarioService _domainService;
        protected readonly ICaixaApplicationMapper _caixaMapper;
        protected readonly ILancamentoFactory _lancamentoFactory;
        protected readonly IValidator<CriarCaixaDto> _validator;

        public CriarCaixaUseCase(IFluxoDiarioService domainService, ICaixaApplicationMapper caixaMapper, 
            IValidator<CriarCaixaDto> validator, ILancamentoFactory lancamentoFactory)
        {
            _domainService = domainService;
            _validator = validator;
            _caixaMapper = caixaMapper;
            _lancamentoFactory = lancamentoFactory;
        }

        public async Task<Result<Caixa>> ExecutarAsync(CriarCaixaDto input, CancellationToken ct = default)
        {
            var validacao = _validator.Validar(input);
            if (validacao.IsFailed)
                return validacao;

            var caixa = _caixaMapper.MapearCaixa(input);

            var resultadoCriacao = await _domainService.CriarCaixaAsync(caixa);

            if(resultadoCriacao.IsFailed)
                return resultadoCriacao;

            if (input.SaldoInicial > 0)
                resultadoCriacao = await _domainService.ComputarLancamentoAsync(resultadoCriacao.Value,
                    _lancamentoFactory.Criar(TipoLancamento.Credito, "Saldo inicial", input.SaldoInicial.Value, DateTime.UtcNow));

            return resultadoCriacao;
        }
    }
}
