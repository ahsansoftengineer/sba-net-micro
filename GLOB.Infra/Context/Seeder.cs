using GLOB.Infra.Context;
using GLOB.Infra.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seedz;
public static partial class Seederz
{
  public static void SeedInfra(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra -> Applying Migrations ModelBuilder");
    mb.SeedTestInfra();
  }
  public static void SeedInfra(this IApplicationBuilder app)
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
        }
      }
    }
  }
}