using GLOB.Domain.Base;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class InfraSeeder
{
  // For DB Context (Normal) (Prod Automate) 
  public static void SeedProjectzLookupzBase(this DBCntxt context)
  {
    if (!context.ProjectzLookupzBases.Any(x => x.Id > 0))
    {
      context.ProjectzLookupzBases.AddRange(SeedDataEntityBase<ProjectzLookupzBase>());
      context.SaveChanges();
    }
  }
  // For DB Context (Identity) (Dev CLI) 
  public static void SeedProjectzLookupzBase(this ModelBuilder builder)
  {
    builder.Entity<ProjectzLookupzBase>().HasData(SeedDataEntityBase<ProjectzLookupzBase>());
  }

  
}