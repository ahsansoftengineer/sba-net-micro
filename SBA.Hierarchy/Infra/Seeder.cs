using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    mb.SeedTestStatus();
    mb.SeedTestParent();
    mb.SeedTestChild();
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
          context.SeedTestStatus();
          context.SeedTestParent();
          context.SeedTestChild();
        }
      }
    }
  }
}