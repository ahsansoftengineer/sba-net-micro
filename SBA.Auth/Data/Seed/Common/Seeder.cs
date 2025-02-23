using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Auth -> Applying Migrations ModelBuilder");
    mb.SeedTestProj();

  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCntxtProj? context = srvcScp.ServiceProvider.GetService<DBCntxtProj>();
      if (context != null)
      {
        Console.WriteLine("--> Auth -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          context.SeedTestProj();
        }
      }
    }
  }

}