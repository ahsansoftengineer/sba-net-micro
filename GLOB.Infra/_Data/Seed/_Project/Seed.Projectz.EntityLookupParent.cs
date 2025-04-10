using GLOB.Domain.Base;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class InfraSeeder
{
  // For DB Context (Normal) (Prod Automate) 
  public static void SeedProjectzEntityLookupBase(this DBCntxt context)
  {
    if (!context.ProjectzEntityLookupBases.Any(x => x.Id > 0))
    {
      context.ProjectzEntityLookupBases.AddRange(SeedDataEntityBase<ProjectzEntityLookupBase>());
      context.SaveChanges();
    }
  }
  // For DB Context (Identity) (Dev CLI) 
  public static void SeedProjectzEntityLookupBase(this ModelBuilder builder)
  {
    builder.Entity<ProjectzEntityLookupBase>().HasData(SeedDataEntityBase<ProjectzEntityLookupBase>());
  }

  
}