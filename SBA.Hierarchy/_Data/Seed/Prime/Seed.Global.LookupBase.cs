using GLOB.Hierarchy.Global;
using Microsoft.EntityFrameworkCore;
using SBA.Projectz.Data;
using GLOB.Infra.Seed;

namespace GLOB.Projectz.Seed;
public static partial class Seeder
{
  // For DB Context (Normal) (Prod Automate) 
  public static void SeedGlobalLookupzBase(this ProjectzDBCntxt context)
  {
    if (!context.GlobalLookupzBases.Any(x => x.Id > 0))
    {
      context.GlobalLookupzBases.AddRange(InfraSeeder.SeedDataEntityBase<GlobalLookupzBase>());
      context.SaveChanges();
    }
  }
  // For DB Context (Identity) (Dev CLI) 
  public static void SeedGlobalLookupzBase(this ModelBuilder builder)
  {
    builder.Entity<GlobalLookupzBase>().HasData(InfraSeeder.SeedDataEntityBase<GlobalLookupzBase>());
  }

  
}