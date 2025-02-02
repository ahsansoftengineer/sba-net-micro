using GLOB.Infra.Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seed;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    mb.SeedTestInfra();
  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContextz? context = srvcScp.ServiceProvider.GetService<AppDBContextz>();
      if (context != null)
      {
        Console.WriteLine("--> Applying Migrations Not Development");
        context.Database.Migrate();
        {
          context.SeedTestInfra();
        }
      }
    }
  }
}