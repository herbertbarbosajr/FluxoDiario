using FluxoDiario.DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FluxoDiario.DataAccess.Contexts
{
    public static class FluxoDiarioDbContextSetup
    {
        public static IServiceCollection SetupDbContexts(this IServiceCollection services)
        {
            services.AddDbContext<FluxoDiarioDbContext>(options =>
            {
                options.UseSqlServer(ConnectionStringProvider.FluxoDiario);
                options.UseSnakeCaseNamingConvention();
            });

            return services;
        }

        public static void EnsureMigrationsApplied(this IServiceProvider sp)
        {
            using (var scope = sp.CreateScope())
            {
                var dbContext = scope.ServiceProvider
                    .GetRequiredService<FluxoDiarioDbContext>();

                dbContext.Database.Migrate();
            }
        }
    }
}
