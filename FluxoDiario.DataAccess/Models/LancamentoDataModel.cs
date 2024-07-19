﻿using FluxoDiario.DataAccess.Models.Interfaces;
using FluxoDiario.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoDiario.DataAccess.Models
{
    public class LancamentoDataModel : IDataModel<int>, IDateInfoDataModel
    {
        public int Id { get; set; }
        public int CaixaId { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public string Descricao { get; set; }
        public TipoLancamento Tipo { get; set; }
        public double Valor { get; set; }
        public DateTime DataLancamento { get; set; }

        public CaixaDataModel Caixa { get; set; }
    }
}
