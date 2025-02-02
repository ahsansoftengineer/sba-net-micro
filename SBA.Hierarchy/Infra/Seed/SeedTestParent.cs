using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
public static partial class Seeder
{
  public static void SeedTestParent(this AppDBContextz context)
  {
    if (!context.TestParents.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data TestParent (Context)");
      context.TestParents.AddRange(DataTestParent);
      context.SaveChanges();
    }
  }
  public static void SeedTestParent(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data TestParent (ModelBuilder)");
    builder.Entity<TestParent>().HasData(DataTestParent);
  }
  public static List<TestParent> DataTestParent = [
    new TestParent
    {
      Id = 1,
      Title = "TestParent 1",
      Desc = "TestParent 1 Desc",
    },
    new TestParent
    {
      Id = 2,
      Title = "TestParent 2",
      Desc = "TestParent 2 Desc",
    },
    new TestParent
    {
      Id = 3,
      Title = "TestParent 3",
      Desc = "TestParent 3 Desc",
    }
];

}