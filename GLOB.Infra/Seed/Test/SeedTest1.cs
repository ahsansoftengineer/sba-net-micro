using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class SeedData
{
  public static void Test1(ModelBuilder mb)
  {
    mb.Entity<Test1>().HasData(
      new Test1
      {
        ID = 1,
        Name = "Test1 1",
        Desc = "Test1 1 Desc",
      },
      new Test1
      {
        ID = 2,
        Name = "Test1 2",
        Desc = "Test1 2 Desc",
      },
      new Test1
      {
        ID = 3,
        Name = "Test1 3",
        Desc = "Test1 3 Desc",
      }
    );
  }
}