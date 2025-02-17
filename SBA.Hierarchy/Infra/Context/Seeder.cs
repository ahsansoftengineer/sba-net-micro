using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Seed;

namespace SBA.Hierarchy.Context;
public static partial class Seeder
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("--> Hierarchy -> Applying Migrations ModelBuilder");
    // mb.SeedTestInfra();
    mb.SeedTestProj();
    // .-*
    mb.SeedOrg();
    mb.SeedBG();
    mb.SeedState();
    mb.SeedBank();
    mb.SeedBrand();
    mb.SeedIndustry();
    mb.SeedProfession();

    // *-.
    mb.SeedSystemz();
    mb.SeedLE();
    mb.SeedOU();
    mb.SeedSU();
    mb.SeedCity();

  }
  // Prod (When Running Migration throw Automation)
  public static void Seed(this IApplicationBuilder app)
  {
    using (var srvcScp = app.ApplicationServices.CreateScope())
    {
      AppDBContextProj? context = srvcScp.ServiceProvider.GetService<AppDBContextProj>();
      if (context != null)
      {
        Console.WriteLine("--> Hierarchy -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          context.SeedTestProj();
          // .-*
          context.SeedOrg();
          context.SeedBG();
          context.SeedState();
          context.SeedBank();
          context.SeedBrand();
          context.SeedIndustry();
          context.SeedProfession();

          // *-.
          context.SeedSystemz();
          context.SeedLE();
          context.SeedOU();
          context.SeedSU(); 
          context.SeedCity(); 
        }
      }
    }
  }

}