using GLOB.Infra.Data;
using GLOB.Infra.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seedz;
public static partial class InfraSeeder
{
  // Seed for Dev (CLI)
  public static void SeedInfra(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra -> Applying Migrations ModelBuilder (Dev)");
    mb.SeedTestInfra();
    mb.SeedEntityShortProjectz();
  }
  // Seed for Production (Automate)
  public static void SeedInfra(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCntxt? context = srvcScp.ServiceProvider.GetService<DBCntxt>();
      if (context != null)
      {
        Console.WriteLine("--> Infra -> Applying Migrations AppBuilder (Prod)");
        context.Database.Migrate();
        {
          context.SeedTestInfra();
          context.SeedEntityShortProjectz();
        }
      }
    }
  }
}