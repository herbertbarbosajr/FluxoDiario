using FluxoDiario.Domain.Contexts.SharedKernel.Tipos;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace FluxoDiario.Presentation.API.Models.FluxoDiario.Requests
{
    public class AdicionarLancamentoRequestModel
    {
        [JsonIgnore]
        [BindNever]
        public int? IdCaixa { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("valor")]
        public double? Valor { get; set; }

        [JsonPropertyName("tipo_lancamento")]
        public TipoLancamento TipoLancamento { get; set; }
    }
}
