using GLOB.Infra.Data;
using GLOB.Infra.Seed;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seedz;
public static partial class SeedzInfra
{
  // Seed for Development through (CLI)
  public static void SeedInfra(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra -> Applying Migrations ModelBuilder (Dev)");
    mb.SeedProjectzLookupBase();
    mb.SeedProjectzLookup();
  }

  // Seed for Production (Automate)
  public static void SeedInfra(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCtx? context = srvcScp.ServiceProvider.GetService<DBCtx>();
      if (context != null)
      {
        Console.WriteLine("--> Infra -> Applying Migrations AppBuilder (Prod)");
        context.Database.Migrate();
        {
          context.SeedProjectzLookupBase();
          context.SeedProjectzLookup();
        }
      }
    }
  }
}