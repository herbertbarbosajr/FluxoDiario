﻿using FluxoDiario.DataAccess.Extensions;
using FluxoDiario.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoDiario.DataAccess.DataModelConfigurations
{
    public class NovoLancamentoDataModelConfiguration : IEntityTypeConfiguration<NovoLancamentoDataModel>
    {
        public void Configure(EntityTypeBuilder<NovoLancamentoDataModel> builder)
        {
            builder.ToTable("historico_lancamentos_caixa");

            builder.ConfigureIdentity<NovoLancamentoDataModel, int>();

            builder.HasOne(x => x.Caixa)
                .WithMany(x => x.HistoricoLancamentos)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.SaldoAtual)
                .IsRequired();

            builder.Property(x => x.SaldoAnterior)
                .IsRequired();
        }
    }
}
