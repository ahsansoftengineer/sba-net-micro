using GLOB.Infra.Common;
using GLOB.Infra.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Common;
public static partial class SeederInfra
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Applying Migrations ModelBuilder");
    mb.SeedTestInfra();
    // mb.SeedLE();
  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContextz? context = srvcScp.ServiceProvider.GetService<AppDBContextz>();
      if (context != null)
      {
        Console.WriteLine("-->Applying Migrations DB Context");
        context.Database.Migrate();
        {
          context.SeedTestInfra();
          // context.SeedLE();
        }
      }
    }
  }
}