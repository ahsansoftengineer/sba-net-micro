using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class SeedData
{
  public static void TestChild(ModelBuilder mb)
  {
    mb.Entity<TestChild>().HasData(
      new TestChild
      {
        Id = 1,
        Title = "TestChild 1",
        Desc = "TestChild 1 Desc",
      },
      new TestChild
      {
        Id = 2,
        Title = "TestChild 2",
        Desc = "TestChild 2 Desc",
      },
      new TestChild
      {
        Id = 3,
        Title = "TestChild 3",
        Desc = "TestChild 3 Desc",
      }
    );
  }
}