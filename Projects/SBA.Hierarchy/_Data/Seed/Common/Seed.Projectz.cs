using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class SeedProjectz
{
  // Dev (When Running Migration throw CLI)
  public static void Seed(this ModelBuilder mb)
  {
    Console.WriteLine("-->  ModelBuilder --> Hierarchy -> SeedProjectz");
    // .-*
    mb.SeedGlobalLookupBase();
    mb.SeedOrg();
    mb.SeedBG();
    mb.SeedState();
    mb.SeedBank();
    mb.SeedBrand();
    mb.SeedIndustry();
    mb.SeedProfession();

    // *-.
    mb.SeedGlobalLookup();
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
      DBCtxProjectz? context = srvcScp.ServiceProvider.GetService<DBCtxProjectz>();
      if (context != null)
      {
        // context.Database.EnsureCreated();
        Console.WriteLine("--> Hierarchy -> Applying Migrations AppBuilder");
        context.Database.Migrate();
        {
          // .-*
          context.SeedGlobalLookupBase();
          context.SeedOrg();
          context.SeedBG();
          context.SeedState();
          context.SeedBank();
          context.SeedBrand();
          context.SeedIndustry();
          context.SeedProfession();

          // *-.
          context.SeedGlobalLookup();
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