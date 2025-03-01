using GLOB.Infra.Context;
using GLOB.Infra.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seedz;
public static partial class Seederz
{
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra -> Applying Migrations ModelBuilder");
    mb.SeedTestInfra();
    // mb.SeedLE();
  }
  public static void Seed(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCntxt? context = srvcScp.ServiceProvider.GetService<DBCntxt>();
      if (context != null)
      {
        Console.WriteLine("--> Infra -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          context.SeedTestInfra();
          // context.SeedLE();
        }
      }
    }
  }
}