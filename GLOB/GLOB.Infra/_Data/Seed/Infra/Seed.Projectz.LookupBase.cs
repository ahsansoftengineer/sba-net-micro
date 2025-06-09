using GLOB.Infra.Model.Base;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class SeedzInfra
{
  // For DB Context (Normal) (Prod Automate) 
  public static void SeedProjectzLookupBase(this DBCtx context)
  {
    if (!context.ProjectzLookupBases.Any(x => x.Id > 0))
    {
      context.ProjectzLookupBases.AddRange(SeedDataEntityBase<ProjectzLookupBase>());
      context.SaveChanges();
    }
  }
  // For DB Context (Identity) (Dev CLI) 
  public static void SeedProjectzLookupBase(this ModelBuilder builder)
  {
    builder.Entity<ProjectzLookupBase>().HasData(SeedDataEntityBase<ProjectzLookupBase>());
  }

  
}