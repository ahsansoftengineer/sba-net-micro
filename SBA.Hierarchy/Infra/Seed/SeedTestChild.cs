using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
public static partial class Seeder
{
  // For K8S Dev
  public static void SeedTestChild(this AppDBContextz context)
  {
    if (!context.TestChilds.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data TestChild (Context)");
      context.TestChilds.AddRange(DataTestChild);
      context.SaveChanges();
    }
  }
  // For Local Dev
  public static void SeedTestChild(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data TestChild (ModelBuilder)");
    builder.Entity<TestChild>().HasData(DataTestChild);
  }
  public static List<TestChild> DataTestChild = [
    new TestChild
    {
      Id = 1,
      Title = "TestChild 1",
      Desc = "TestChild 1 Desc",
      TestParentId = 1,
    },
    new TestChild
    {
      Id = 2,
      Title = "TestChild 2",
      Desc = "TestChild 2 Desc",
      TestParentId = 2,
    },
    new TestChild
    {
      Id = 3,
      Title = "TestChild 3",
      Desc = "TestChild 3 Desc",
      TestParentId = 1,
    }
];

}