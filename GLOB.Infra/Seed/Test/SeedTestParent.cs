using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class SeedData
{
  public static void TestParent(ModelBuilder mb)
  {
    mb.Entity<TestParent>().HasData(
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
    );
  }
}