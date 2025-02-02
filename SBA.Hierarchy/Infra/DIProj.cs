using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Infra;

namespace GLOB.Infra;
public static class DI
{
  public static void AddSrvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddPersistence(config);
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
    srvc.AddTransient<IUOW, UOW>();
  }
}