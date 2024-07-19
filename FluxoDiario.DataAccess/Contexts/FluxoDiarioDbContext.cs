using FluxoDiario.DataAccess.DataModelConfigurations;
using FluxoDiario.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace FluxoDiario.DataAccess.Contexts
{
    public class FluxoDiarioDbContext : DbContext
    {
        public FluxoDiarioDbContext(DbContextOptions<FluxoDiarioDbContext> options) : base(options) { }

        public DbSet<CaixaDataModel> Caixas { get; set; }
        public DbSet<LancamentoDataModel> Lancamentos { get; set; }
        public DbSet<RelatorioDataModel> Relatorios { get; set; }

        public DbSet<NovoLancamentoDataModel> HistoricoLancamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CaixaDataModelConfiguration());
            modelBuilder.ApplyConfiguration(new LancamentoDataModelConfiguration());
            modelBuilder.ApplyConfiguration(new NovoLancamentoDataModelConfiguration());
            modelBuilder.ApplyConfiguration(new RelatorioDataModelConfiguration());
        }
    }
}
