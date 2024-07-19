﻿using FluxoDiario.Domain.Contexts.Relatorios.Tipos;

namespace FluxoDiario.Application.Dtos.Relatorios
{
    public class CriarRelatorioDto
    {
        public int? IdCaixa { get; set; }
        public TipoRelatorio? TipoRelatorio { get; set; }
        public DateOnly? Data { get; set; }
    }
}
