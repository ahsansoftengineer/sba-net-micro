using Microsoft.EntityFrameworkCore;
using GLOB.Infra.UOW;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace GLOB.INFRA.DI;
public static partial class DI_Infra
{

  public static void Config_DB_SQL<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config)
    where TContext : DbContext
    where TIUOW : class, IUnitOfWorkz
    where TUOW : UnitOfWorkz, TIUOW
  {
    string connStr = config.GetConnectionString("SqlConnection");
    
    srvc.AddDbContext<TContext>(opt =>
    {
      opt.EnableSensitiveDataLogging(true);
      opt.UseSqlServer(connStr, sqlOptions =>
      {
        sqlOptions.EnableRetryOnFailure(
          maxRetryCount: 1,
          maxRetryDelay: TimeSpan.FromSeconds(3),
          errorNumbersToAdd: null
        );
      });
      opt.LogTo(Console.WriteLine, LogLevel.Information);
    });

    srvc.AddScoped<TIUOW, TUOW>();
  }
}

// "ConnectionStrings": {
//   "SqlConnection": "Server=127.0.0.1,1430;Initial Catalog=SBA_Auth;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"
// },

