using GLOB.Proj.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Infra;
using SBA.Hierarchy.Seed;

namespace SBA.Hierarchy.Common;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Applying Migrations ModelBuilder");
    mb.SeedTestProj();
    mb.SeedOrg();
    mb.SeedSystemz();
    mb.SeedBG();
    mb.SeedLE();
    mb.SeedOU();
    mb.SeedSU();

  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContextProj? context = srvcScp.ServiceProvider.GetService<AppDBContextProj>();
      if (context != null)
      {
        Console.WriteLine("--> Applying Migrations Context");
        context.Database.Migrate();
        {
          context.SeedTestProj();
        }
      }
    }
  }

}