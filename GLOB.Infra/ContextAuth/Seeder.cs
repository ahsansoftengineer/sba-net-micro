using GLOB.Infra.Context.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using GLOB.Infra.Seed;

namespace GLOB.Infra.Seedz;
public static partial class SeederIdentity
{
  public static IApplicationBuilder app;
  public static void SeedIdentity(this ModelBuilder mb)
  {
    Console.WriteLine("--> Infra Identity -> Applying Migrations ModelBuilder");
    mb.SeedTestInfra();
    // mb.Entity<UserInfra>().HasData();
  }
  public static async Task SeedIdentity(this IApplicationBuilder app)
  {
    using(var srvcScp = app.ApplicationServices.CreateScope())
    {
      var srvc = srvcScp.ServiceProvider;
      var context = srvc.GetService<DBCntxtIdentity>();
      var userManager = srvc.GetRequiredService<UserManager<IdentityUser>>();
      var roleManager = srvc.GetRequiredService<RoleManager<IdentityRole>>();
      if (context != null)
      {
        Console.WriteLine("--> Infra Identity -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          await userManager.SeedUserInfra();
          // context.SeedTestInfra();
          // context.SeedLE();
        }
      }
    }
  }
}