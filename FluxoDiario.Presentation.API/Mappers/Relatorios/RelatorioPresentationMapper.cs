﻿using FluentResults;
using FluxoDiario.Application.Dtos;
using FluxoDiario.Application.Dtos.Relatorios;
using FluxoDiario.Domain.Contexts.Relatorios;
using FluxoDiario.Presentation.API.Mappers.Relatorios.Interfaces;
using FluxoDiario.Presentation.API.Models;
using FluxoDiario.Presentation.API.Models.Relatorios.Requests;
using FluxoDiario.Presentation.API.Models.Relatorios.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDiario.Presentation.API.Mappers.Relatorios
{
    public class RelatorioPresentationMapper : IRelatorioPresentationMapper
    {
        public CriarRelatorioDto CriarRelatorioDto(CriarRelatorioRequestModel model)
        {
            return new CriarRelatorioDto()
            {
                IdCaixa = model.IdCaixa,
                Data = model.DataRelatorio == null ? null : DateOnly.FromDateTime(model.DataRelatorio.Value),
                TipoRelatorio = model.TipoRelatorio,
            };
        }

        public IActionResult CriarRelatorioResponse(Result<Relatorio> result)
        {
            if(result.IsFailed) 
                return ResponseMessage.Falha(result.Errors?.Select(x => x.Message));

            var relatorio = result.Value;

            var responseModel = new CriarRelatorioResponseModel(relatorio.Id, relatorio.Status);
            return ResponseMessage.Sucesso(responseModel, 201);
        }

        public IActionResult CriarStatusRelatorioResponse(Result<Relatorio> result)
        {
            if (result.IsFailed)
                return ResponseMessage.Falha(result.Errors?.Select(x => x.Message));
            
            var relatorio = result.Value;

            var responseModel = new ConsultarStatusResponseModel(relatorio.Id, relatorio.Status);
            return ResponseMessage.Sucesso(responseModel);
        }


        public IActionResult CriarDownloadRelatorioResponse(Result<FileDto> result)
        {
            if (result.IsFailed)
                return ResponseMessage.Falha(result.Errors?.Select(x => x.Message));

            var dto = result.Value;

            return new FileContentResult(dto.Conteudo, dto.MimeType) { FileDownloadName = dto.Nome };
        }
    }
}
