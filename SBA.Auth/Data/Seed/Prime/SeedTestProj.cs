using GLOB.Domain.Hierarchy;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;

namespace SBA.Projectz.Data;
public static partial class Seeder
{
  public static void SeedTestProj(this AppDBContextProj context)
  {
    if (!context.TestProjs.Any(x => x.Id > 0))
    {
      context.TestProjs.AddRange(Seederz.SeedDataBaseEntity<TestProj>());
      context.SaveChanges();
    }
  }
  public static void SeedTestProj(this ModelBuilder builder)
  {
    builder.Entity<TestProj>().HasData(Seederz.SeedDataBaseEntity<TestProj>());
  }
  

}