using FluxoDiario.Domain.Contexts.Relatorios.Tipos;

namespace FluxoDiario.Presentation.API.Models.Relatorios.Responses
{
    public readonly record struct CriarRelatorioResponseModel(int id, StatusRelatorio status);
}
