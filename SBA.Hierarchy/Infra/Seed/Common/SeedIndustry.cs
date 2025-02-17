using GLOB.Domain.Entity;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Context;

namespace SBA.Hierarchy.Seed;
public static partial class Seeder
{
  public static void SeedIndustry(this AppDBContextProj context)
  {
    if (!context.Industrys.Any(x => x.Id > 0))
    {
      context.Industrys.AddRange(Seederz.SeedDataBaseEntity<Industry>());
      context.SaveChanges();
    }
  }
  public static void SeedIndustry(this ModelBuilder builder)
  {
    builder.Entity<Industry>().HasData(Seederz.SeedDataBaseEntity<Industry>());
  }
  

}