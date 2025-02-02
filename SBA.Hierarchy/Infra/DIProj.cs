using GLOB.Apps.Common;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Infra;

namespace GLOB.Infra;
public static class DI
{
  public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration Configuration)
  {
    services
      .AddPersistence(Configuration);
    return services;
  }
  public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration Configuration)
  {
    services.AddDbContext<AppDBContextz>(options =>
    {
      options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"));
    });
    services.AddTransient<IUOW, UOW>();

    return services;
  }
}