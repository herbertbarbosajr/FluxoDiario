using FluxoDiario.Shared.Environments;

namespace FluxoDiario.DataAccess.Configurations
{
    internal class ConnectionStringProvider
    {
        public static string FluxoDiario =>
            Environment.GetEnvironmentVariable(EnvironmentVariables.DefaultDbConnectionString) ??
            "Server=DESKTOP-SSE2VN1\\SQLEXPRESS01; Database=FluxoDiarioDB; Trusted_Connection=True; MultipleActiveResultSets=True;TrustServerCertificate=true";
    }
}
