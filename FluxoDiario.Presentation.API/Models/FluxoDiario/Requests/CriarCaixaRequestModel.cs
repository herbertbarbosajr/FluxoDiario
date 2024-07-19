using System.Text.Json.Serialization;

namespace FluxoDiario.Presentation.API.Models.FluxoDiario.Requests
{
    public class CriarCaixaRequestModel
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("saldo_inicial")]
        public double? SaldoInicial { get; set; }
    }
}
