using GLOB.Domain.Entity;
using GLOB.Infra.Seed;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Common;

namespace SBA.Hierarchy.Seed;
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