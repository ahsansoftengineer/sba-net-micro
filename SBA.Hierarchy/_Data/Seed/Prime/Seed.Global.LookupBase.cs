using GLOB.Hierarchy.Global;
using Microsoft.EntityFrameworkCore;
using SBA.Projectz.Data;
using GLOB.Infra.Seed;

namespace GLOB.Projectz.Seed;
public static partial class Seeder
{
  // For DB Context (Normal) (Prod Automate) 
  public static void SeedGlobalLookupzzBase(this ProjectzDBCntxt context)
  {
    if (!context.GlobalLookupzzBases.Any(x => x.Id > 0))
    {
      context.GlobalLookupzzBases.AddRange(InfraSeeder.SeedDataEntityBase<GlobalLookupzzBase>());
      context.SaveChanges();
    }
  }
  // For DB Context (Identity) (Dev CLI) 
  public static void SeedGlobalLookupzzBase(this ModelBuilder builder)
  {
    builder.Entity<GlobalLookupzzBase>().HasData(InfraSeeder.SeedDataEntityBase<GlobalLookupzzBase>());
  }

  
}