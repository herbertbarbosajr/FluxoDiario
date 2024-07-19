using FluentResults;
using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Application.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Application.Services.FluxoDiario;
using FluxoDiario.Application.UseCases.FluxoDiario.Interfaces;
using FluxoDiario.Application.Validators;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Domain.Services.FluxoDiario;

namespace FluxoDiario.Application.UseCases.FluxoDiario
{
    public class AdicionarLancamentoUseCase : IAdicionarLancamentoUseCase
    {
        private readonly IFluxoDiarioService _domainService;
        private readonly IFluxoDiarioApplicationService _applicationService;
        private readonly IValidator<AdicionarLancamentoDto> _validator;
        private readonly ILancamentoApplicationMapper _mapper;

        public AdicionarLancamentoUseCase(
            IFluxoDiarioService domainService,
            IFluxoDiarioApplicationService applicationService,
            IValidator<AdicionarLancamentoDto> validator,
            ILancamentoApplicationMapper mapper
            )
        {
            _domainService = domainService;
            _applicationService = applicationService;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Caixa>> ExecutarAsync(AdicionarLancamentoDto input, CancellationToken ct = default)
        {
            var validacao = _validator.Validar(input);
            if (validacao.IsFailed)
                return validacao;

            var resultadoBuscaCaixa = await _applicationService.ObterCaixaObrigatoriaAsync(input.IdCaixa.Value, ct);
            if(resultadoBuscaCaixa.IsFailed)
                return resultadoBuscaCaixa;

            var lancamento = _mapper.MapearLancamento(input);

            return await _domainService.ComputarLancamentoAsync(resultadoBuscaCaixa.Value, lancamento, ct);
        }
    }
}
