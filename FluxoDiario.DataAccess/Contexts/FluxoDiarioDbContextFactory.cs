using FluxoDiario.DataAccess.Configurations;
using FluxoDiario.Shared.Logs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Serilog;

namespace FluxoDiario.DataAccess.Contexts
{
    public class FluxoDiarioDbContextFactory : IDesignTimeDbContextFactory<FluxoDiarioDbContext>
    {
        public FluxoDiarioDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<FluxoDiarioDbContext>();
            var connectionString = ConnectionStringProvider.FluxoDiario;

            if (connectionString == null)
            {
                Log.Logger.Error($"{LogVariables.ClassAndMethodName} Não foi possível obter a ConnectionString do banco de dados.",
                    nameof(FluxoDiarioDbContextFactory), nameof(CreateDbContext));

                throw new ArgumentNullException("ConnectionString não informada.");
            }

            builder.UseSqlServer(connectionString);
            builder.UseSnakeCaseNamingConvention();

            return new FluxoDiarioDbContext(builder.Options);
        }
    }
}
