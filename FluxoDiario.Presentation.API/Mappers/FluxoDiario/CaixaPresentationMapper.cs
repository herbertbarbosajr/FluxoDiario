using FluentResults;
using FluxoDiario.Application.Dtos.FluxoDiario;
using FluxoDiario.Domain.Contexts.FluxoDiario;
using FluxoDiario.Presentation.API.Mappers.FluxoDiario.Extensions;
using FluxoDiario.Presentation.API.Mappers.FluxoDiario.Interfaces;
using FluxoDiario.Presentation.API.Models;
using FluxoDiario.Presentation.API.Models.FluxoDiario.Requests;
using FluxoDiario.Presentation.API.Models.FluxoDiario.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FluxoDiario.Presentation.API.Mappers.FluxoDiario
{
    public class CaixaPresentationMapper : ICaixaPresentationMapper
    {
        public ObjectResult CriarCaixaResponse(Result<Caixa> result)
        {
            if (result.IsFailed)
                return ResponseMessage.Falha(result.Errors.Select(x => x.Message));

            var caixaResponseModel = result.Value.ToResponseModel();

            return ResponseMessage.Sucesso(new CriarCaixaResponseModel(caixaResponseModel), 201);
        }

        public ObjectResult AdicionarLancamentoResponse(Result<Caixa> result)
        {
            if (result.IsFailed)
                return ResponseMessage.Falha(result.Errors.Select(x => x.Message));

            var caixaResponseModel = result.Value.ToResponseModel();

            return ResponseMessage.Sucesso(new AdicionarLancamentoResponseModel(caixaResponseModel), 201);
        }

        public ObjectResult ConsultarSaldoResponse(Result<ConsultarSaldoDto> result)
        {
            if (result.IsFailed)
                return ResponseMessage.Falha(result.Errors.Select(x => x.Message), 404);

            return ResponseMessage.Sucesso(result.Value.ToResponseModel());
        }

        public CriarCaixaDto CriarCaixaDto(CriarCaixaRequestModel request)
        {
            return new CriarCaixaDto()
            {
                Nome = request.Nome,
                SaldoInicial = request.SaldoInicial
            };
        }

        public AdicionarLancamentoDto AdicionarLancamentoDto(AdicionarLancamentoRequestModel requestModel)
        {
            return new AdicionarLancamentoDto()
            {
                IdCaixa = requestModel.IdCaixa,
                DataLancamento = null, //será implementado no futuro
                Valor = requestModel.Valor,
                Descricao = requestModel.Descricao,
                TipoLancamento = requestModel.TipoLancamento
            };
        }
    }
}
