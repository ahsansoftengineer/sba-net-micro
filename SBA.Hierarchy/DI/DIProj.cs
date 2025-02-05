using GLOB.API.DI;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Infra;

namespace SBA.Hierarchy.DI;
public static class DI
{
  public static void AddSrvc(this IServiceCollection srvc, IConfiguration config)
  {
    AddPersistence(srvc, config);
    srvc.AddScoped<IUOW, UOW>();
    srvc.Config_DB_SQL(config);
  }
  public static void AddPersistence(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddDbContext<AppDBContextProj>(opt =>
    {
      string connStr = config.GetConnectionString("SqlConnection");
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
  }
}