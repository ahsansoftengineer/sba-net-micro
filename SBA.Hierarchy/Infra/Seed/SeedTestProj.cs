using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Infra;

namespace GLOB.Proj.Seed;
public static partial class Seeder
{
  public static void SeedTestProj(this AppDBContextProj context)
  {
    if (!context.TestProjs.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data TestProj (Context)");
      context.TestProjs.AddRange(DataTestProj);
      context.SaveChanges();
    }
  }
  public static void SeedTestProj(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data TestProj (ModelBuilder)");
    builder.Entity<TestProj>().HasData(DataTestProj);
  }
  public static List<TestProj> DataTestProj = [
    new TestProj
    {
      Id = 1,
      Title = "TestProj 1",
      Desc = "TestProj 1 Desc",
    },
    new TestProj
    {
      Id = 2,
      Title = "TestProj 2",
      Desc = "TestProj 2 Desc",
    },
    new TestProj
    {
      Id = 3,
      Title = "TestProj 3",
      Desc = "TestProj 3 Desc",
    }
  ];

}