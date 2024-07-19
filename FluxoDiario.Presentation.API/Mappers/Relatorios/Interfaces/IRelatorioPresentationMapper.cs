using FluentResults;
using FluxoDiario.Application.Dtos;
using FluxoDiario.Application.Dtos.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Presentation.API.Models.Relatorios.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDiario.Presentation.API.Mappers.Relatorios.Interfaces
{
    public interface IRelatorioPresentationMapper
    {
        CriarRelatorioDto CriarRelatorioDto(CriarRelatorioRequestModel model);

        IActionResult CriarRelatorioResponse(Result<Relatorio> result);
        IActionResult CriarStatusRelatorioResponse(Result<Relatorio> result);
        IActionResult CriarDownloadRelatorioResponse(Result<FileDto> result);
    }
}
