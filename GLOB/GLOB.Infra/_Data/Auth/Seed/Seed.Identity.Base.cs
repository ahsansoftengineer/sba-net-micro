using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using GLOB.Domain.Model.Auth;
using GLOB.Infra.Data.Seedz;

namespace GLOB.Infra.Data.Auth;
public static partial class InfraSeederIdentity
{
  public static IApplicationBuilder app;
  // Seed for Development through (CLI)
  public static void SeedInfraIdentity(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra Identity -> Applying Migrations ModelBuilder (Dev)");
    mb.SeedInfra();
    mb.SeedInfraRole();
    mb.SeedInfraUser();
    // mb.SeedRefreshToken();
  }
  // Seed for Production (Automate)
  public static async Task SeedInfraIdentity(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      var srvc = srvcScp.ServiceProvider;
      var context = srvc.GetService<DBCtxIdentity>();
      var contextz = srvc.GetService<DBCtx>();
      var userManager = srvc.GetRequiredService<UserManager<InfraUser>>();
      var roleManager = srvc.GetRequiredService<RoleManager<InfraRole>>();

      if (context != null)
      {
        Console.WriteLine("--> Infra Identity -> Applying Migrations AppBuilder (Prod)");
        context.Database.Migrate();
        {
          await roleManager.SeedInfraRole();
          await userManager.SeedInfraUser();
          // await context.SeedRefreshToken();
          app.SeedInfra(); //context.SeedTestInfra();
          // context.SeedRefreshToken();
          // context.SeedLE();
        }
      }
    }
  }
}