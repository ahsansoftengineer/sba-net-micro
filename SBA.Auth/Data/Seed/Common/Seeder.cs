using System.Threading.Tasks;
using GLOB.Infra.Context;
using GLOB.Infra.Seed;
using GLOB.Infra.Seedz;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Auth -> Applying Migrations ModelBuilder");
    mb.SeedInfra();
    mb.SeedTestProj();

  }
  // Prod (When Running Migration throw Automation)
  public static async Task Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    { 
      var provider = srvcScp.ServiceProvider;
      DBCntxtProj? context = provider.GetService<DBCntxtProj>();
      DBCntxt contextz = provider.GetService<DBCntxt>();
      if (context != null)
      {
        Console.WriteLine("--> Auth -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          // contextz.SeedTestInfra();
          await app.SeedInfraIdentity();
        }
      }
    }
  }

}