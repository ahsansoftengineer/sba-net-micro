using GLOB.Proj.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    mb.SeedTestProj();
  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContextProj? context = srvcScp.ServiceProvider.GetService<AppDBContextProj>();
      if (context != null)
      {
        Console.WriteLine("--> Applying Migrations Not Development");
        context.Database.Migrate();
        {
          context.SeedTestProj();
        }
      }
    }
  }
}