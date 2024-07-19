using FluxoDiario.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluxoDiario.Tests.Integrations.Configuration
{
    public class LocalDbContextProvider
    {
        public static FluxoDiarioDbContext New()
        {
            var options = new DbContextOptionsBuilder<FluxoDiarioDbContext>()
                .UseInMemoryDatabase(databaseName: "FluxoDiarioDb")
                .Options;

            return new FluxoDiarioDbContext(options);
        }
    }
}
