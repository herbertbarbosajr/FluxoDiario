using System.Text.Json.Serialization;

namespace FluxoDiario.Presentation.API.Models.FluxoDiario.Responses
{
    public readonly record struct LancamentoResponseModel(int id, double valor, string descricao, string tipo, string data);
}
