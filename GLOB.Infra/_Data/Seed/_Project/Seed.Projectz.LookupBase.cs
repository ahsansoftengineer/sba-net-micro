using GLOB.Domain.Base;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class InfraSeeder
{
  // For DB Context (Normal) (Prod Automate) 
  public static void SeedProjectzLookupzzBase(this DBCntxt context)
  {
    if (!context.ProjectzLookupzzBases.Any(x => x.Id > 0))
    {
      context.ProjectzLookupzzBases.AddRange(SeedDataEntityBase<ProjectzLookupzzBase>());
      context.SaveChanges();
    }
  }
  // For DB Context (Identity) (Dev CLI) 
  public static void SeedProjectzLookupzzBase(this ModelBuilder builder)
  {
    builder.Entity<ProjectzLookupzzBase>().HasData(SeedDataEntityBase<ProjectzLookupzzBase>());
  }

  
}