using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Data.Sqlz;
public static partial class SeedzInfra
{
  // Seed for Development through (CLI)
  public static void SeedInfra(this ModelBuilder mb)
  {
    "--> ModelBuilder -> Infra -> SeedzInfra (Dev)".Print("[EF Core]");
    mb.SeedProjectzLookupBase();
    mb.SeedProjectzLookup();
  }

  // Seed for Production (Automate)
  public static void SeedInfra(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      DBCtxInfra? context = srvcScp.ServiceProvider.GetSrvc<DBCtxInfra>();
      if (context != null)
      {
        "--> Infra -> Applying Migrations AppBuilder (Prod)".Print("[EF Core]");
        // context.Database.Migrate();
        {
          context.SeedProjectzLookupBase();
          context.SeedProjectzLookup();
        }
      }
    }
  }
}