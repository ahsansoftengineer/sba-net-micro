using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using GLOB.Infra.UOW;

namespace GLOB.Infra.DI;
public static partial class DI_Infra
{

  public static void Add_Infra_DB_SQL<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config)
    where TContext : DbContext
    where TIUOW : class, IUOW_Infra
    where TUOW : UOW_Infra, TIUOW
  {
    string connStr = config.GetConnectionString("SqlConnection");
    
    srvc.AddDbContext<TContext>(opt =>
    {
      opt.EnableDetailedErrors();
      opt.EnableSensitiveDataLogging();
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

