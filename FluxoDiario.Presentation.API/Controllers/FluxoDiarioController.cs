﻿using FluxoDiario.Application.UseCases.FluxoDiario.Interfaces;
using FluxoDiario.Presentation.API.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Presentation.API.Models.FluxoDiario.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDiario.Presentation.API.Controllers
{
    [Route("api/fluxo_diario")]
    [ApiController]
    public class FluxoDiarioController : ControllerBase
    {
        private readonly ICaixaPresentationMapper _mapper;

        public FluxoDiarioController(ICaixaPresentationMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpPost("caixas")]
        public async Task<IActionResult> CriarCaixa(
            [FromBody] CriarCaixaRequestModel criarCaixa,
            [FromServices] ICriarCaixaUseCase useCase,
            CancellationToken ct)
        {

            var dto = _mapper.CriarCaixaDto(criarCaixa);

            var result = await useCase.ExecutarAsync(dto, ct);

            return _mapper.CriarCaixaResponse(result);
        }

        [HttpGet("caixas/{id_caixa}/saldo")]
        public async Task<IActionResult> ConsultarSaldo(
            [FromRoute] int id_caixa,
            [FromServices] IConsultarSaldoUseCase useCase,
            CancellationToken ct)
        {
            var result = await useCase.ExecutarAsync(id_caixa, ct);
            return _mapper.ConsultarSaldoResponse(result);
        }

        [HttpPost("caixas/{id_caixa}/lancamentos")]
        public async Task<IActionResult> AdicionarLancamento(
            [FromRoute] int id_caixa,
            [FromBody] AdicionarLancamentoRequestModel requestModel,
            [FromServices] IAdicionarLancamentoUseCase useCase,
            CancellationToken ct)
        {
            requestModel.IdCaixa = id_caixa;
            var dto = _mapper.AdicionarLancamentoDto(requestModel);

            var result = await useCase.ExecutarAsync(dto, ct);

            return _mapper.AdicionarLancamentoResponse(result);
        }
    }
}
