using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
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