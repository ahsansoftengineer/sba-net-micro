using GLOB.Infra.Data.Sqlz;
using GLOB.Infra.Data.Auth;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class SeedProjectz
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("-->  ModelBuilder --> Auth -> SeedProjectz");
    mb.SeedInfraIdentity(); // base.OnModelCreating

  }
  // Prod (When Running Migration throw Automation)
  public static async Task Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    { 
      var provider = srvcScp.ServiceProvider;
      DBCtxProjectz? context = provider.GetService<DBCtxProjectz>();
      DBCtx contextz = provider.GetService<DBCtx>();
      if (context != null)
      {
        Console.WriteLine("--> Auth -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          await app.SeedInfraIdentity();
        }
      }
    }
  }

}