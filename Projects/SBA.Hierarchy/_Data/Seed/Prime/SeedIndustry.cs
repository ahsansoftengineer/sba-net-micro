using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedIndustry(this DBCtxProjectz context)
  {
    if (!context.Industrys.Any(x => x.Id > 0))
    {
      context.Industrys.AddRange(InfraSeeder.SeedDataEntityBase<Industry>());
      context.SaveChanges();
    }
  }
  public static void SeedIndustry(this ModelBuilder builder)
  {
    builder.Entity<Industry>().HasData(InfraSeeder.SeedDataEntityBase<Industry>());
  }
  

}