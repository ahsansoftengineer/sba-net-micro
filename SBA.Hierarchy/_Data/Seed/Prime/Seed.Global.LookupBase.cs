using GLOB.Hierarchy.Global;
using Microsoft.EntityFrameworkCore;
using SBA.Projectz.Data;
using GLOB.Infra.Seed;

namespace GLOB.Projectz.Seed;
public static partial class Seeder
{
  // For DB Context (Normal) (Prod Automate) 
  public static void SeedGlobalLookupBase(this ProjectzDBCntxt context)
  {
    if (!context.GlobalLookupBases.Any(x => x.Id > 0))
    {
      context.GlobalLookupBases.AddRange(InfraSeeder.SeedDataEntityBase<GlobalLookupBase>());
      context.SaveChanges();
    }
  }
  // For DB Context (Identity) (Dev CLI) 
  public static void SeedGlobalLookupBase(this ModelBuilder builder)
  {
    builder.Entity<GlobalLookupBase>().HasData(InfraSeeder.SeedDataEntityBase<GlobalLookupBase>());
  }

  
}