using System.Text.Json.Serialization;

namespace FluxoDiario.Presentation.API.Models.FluxoDiario.Responses
{
    public readonly record struct CaixaResponseModel(int id, string nome, IEnumerable<LancamentoResponseModel> lancamentos, double saldo_atual);
}
