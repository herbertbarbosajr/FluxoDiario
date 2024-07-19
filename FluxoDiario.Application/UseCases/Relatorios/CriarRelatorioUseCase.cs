using FluentResults;
using FluxoDiario.Application.Dtos.Relatorios;
using FluxoDiario.Application.Mappers.Relatorios.Interfaces;
using FluxoDiario.Application.UseCases.Relatorios.Interfaces;
using FluxoDiario.Application.Validators;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios.Tipos;
using FluxoDiario.Domain.Repositories.Relatorios;
using FluxoDiario.Domain.Services.Relatorios;
using FluxoDiario.Shared.Results.Relatorios;
using Serilog;

namespace FluxoDiario.Application.UseCases.Relatorios
{
    public class CriarRelatorioUseCase : ICriarRelatorioUseCase
    {
        protected readonly ILogger _logger;
        protected readonly IRelatorioReadRepository _relatorioReadRepository;
        protected readonly IRelatorioService _domainService;
        protected readonly IValidator<CriarRelatorioDto> _validator;
        protected readonly IRelatorioApplicationMapper _mapper;

        public CriarRelatorioUseCase(ILogger logger, IRelatorioReadRepository relatorioReadRepository, IRelatorioService domainService, IValidator<CriarRelatorioDto> validator, IRelatorioApplicationMapper mapper)
        {
            _logger = logger;
            _relatorioReadRepository = relatorioReadRepository;
            _domainService = domainService;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<Result<Relatorio>> ExecutarAsync(CriarRelatorioDto input, CancellationToken ct = default)
        {
            var validation = _validator.Validar(input);
            if (validation.IsFailed)
                return validation;

            var idCaixa = input.IdCaixa.Value;
            var caixaExiste = await _relatorioReadRepository.VerificarCaixaExisteAsync(idCaixa);

            if (caixaExiste.IsFailed)
                return new CaixaNaoExisteResult($"Caixa não existe. Id informado: {idCaixa}");

            var relatorio = _mapper.MapearNovoRelatorio(input, StatusRelatorio.NaFila);

            return await _domainService.CriarRelatorioAsync(relatorio, idCaixa);
        }
    }
}
