using FluentResults;
using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Presentation.API.Models.FluxoDiario.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDiario.Presentation.API.Mappers.FluxoDiario.Interfaces
{
    public interface ICaixaPresentationMapper
    {
        CriarCaixaDto CriarCaixaDto(CriarCaixaRequestModel request);
        AdicionarLancamentoDto AdicionarLancamentoDto(AdicionarLancamentoRequestModel requestModel);

        ObjectResult CriarCaixaResponse(Result<Caixa> result);
        ObjectResult AdicionarLancamentoResponse(Result<Caixa> result);
        ObjectResult ConsultarSaldoResponse(Result<ConsultarSaldoDto> result);
    }
}
