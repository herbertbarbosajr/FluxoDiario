using FluxoDiario.DataAccess.Extensions;
using FluxoDiario.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluxoDiario.DataAccess.DataModelConfigurations
{
    public class CaixaDataModelConfiguration : IEntityTypeConfiguration<CaixaDataModel>
    {
        public void Configure(EntityTypeBuilder<CaixaDataModel> builder)
        {
            builder.ToTable("caixas");

            builder.ConfigureIdentity<CaixaDataModel, int>();
            builder.ConfigureDateInfo();

            builder.HasMany(x => x.HistoricoLancamentos)
                .WithOne(x => x.Caixa)
                .HasForeignKey(x => x.CaixaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Lancamentos)
                .WithOne(x => x.Caixa)
                .HasForeignKey(x => x.CaixaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Property(x => x.Nome)
                .IsRequired();
        }
    }
}
