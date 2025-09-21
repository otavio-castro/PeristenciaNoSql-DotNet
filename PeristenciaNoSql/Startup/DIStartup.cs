using PeristenciaNoSql.Models;
using PeristenciaNoSql.Services;
using PeristenciaNoSql.Services.Interfaces;

namespace PeristenciaNoSql.Startup
{
    public class DIStartup
    {
        public static void ConfigureServices(IHostApplicationBuilder builder)
        {
            #region DbContext

            builder.Services.Configure<AlunoDbSettingsConnection>
                (builder.Configuration.GetSection("AlunoDatabase"));

            #endregion DbContext

            #region Services

            builder.Services.AddSingleton<IAlunosServices, AlunosServices>();

            #endregion Services
        }
    }
}