using GLOB.Infra.Data.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using GLOB.Infra.Seed;
using GLOB.Infra.Data;
using GLOB.Domain.Auth;

namespace GLOB.Infra.Seedz;
public static partial class InfraSeederIdentity
{
  public static IApplicationBuilder app;
  // Seed for Dev (CLI)
  public static void SeedInfraIdentity(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra Identity -> Applying Migrations ModelBuilder (Dev)");
    mb.SeedInfra(); // mb.SeedTestInfra();
    mb.SeedInfraRole();
  }
  // Seed for Production (Automate)
  public static async Task SeedInfraIdentity(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      var srvc = srvcScp.ServiceProvider;
      var context = srvc.GetService<DBCntxtIdentity>();
      var contextz = srvc.GetService<DBCntxt>();
      var userManager = srvc.GetRequiredService<UserManager<InfraUser>>();
      var roleManager = srvc.GetRequiredService<RoleManager<InfraRole>>();
      if (context != null)
      {
        Console.WriteLine("--> Infra Identity -> Applying Migrations AppBuilder (Prod)");
        context.Database.Migrate();
        {
          // await userManager.SeedInfraUser();
          await roleManager.SeedInfraRole();
          app.SeedInfra(); //context.SeedTestInfra();
          // context.SeedLE();
        }
      }
    }
  }
}