using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Infra;

namespace GLOB.Infra;
public static class DI
{
  public static void AddInfra(this IServiceCollection srvc, IConfiguration Configuration)
  {
    srvc
      .AddPersistence(Configuration);
  }
  public static void AddPersistence(this IServiceCollection srvc, IConfiguration _config)
  {
    srvc.AddDbContext<AppDBContextProj>(opt =>
    {
      string connStr = _config.GetConnectionString("SqlConnection");
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