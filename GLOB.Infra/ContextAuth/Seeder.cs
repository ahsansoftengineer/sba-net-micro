using GLOB.Infra.Auth;
using GLOB.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seedz;
public static partial class SeederIdentity
{
  public static void SeedIdentity(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra Identity -> Applying Migrations ModelBuilder");
    // mb.SeedTestInfra();
    // mb.SeedLE();
  }
  public static void SeedIdentity(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCntxtIdentity? context = srvcScp.ServiceProvider.GetService<DBCntxtIdentity>();
      if (context != null)
      {
        Console.WriteLine("--> Infra Identity -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          // context.SeedTestInfra();
          // context.SeedLE();
        }
      }
    }
  }
}