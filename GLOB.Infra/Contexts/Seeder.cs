using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Context;
public static partial class SeederIdentity
{
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra -> Applying Migrations ModelBuilder");
    // mb.SeedTestInfra();
    // mb.SeedLE();
  }
  public static void Seed(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCntxtIdentity? context = srvcScp.ServiceProvider.GetService<DBCntxtIdentity>();
      if (context != null)
      {
        Console.WriteLine("--> Infra -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          // context.SeedTestInfra();
          // context.SeedLE();
        }
      }
    }
  }
}