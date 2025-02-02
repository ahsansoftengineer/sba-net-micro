using GLOB.Domain.Entity;
using GLOB.Domain.Enums;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace SBA.Hierarchy.Infra;
public static partial class Seeder
{
  public static void SeedTestStatus(this AppDBContextz context)
  {
    if (!context.TestStatuss.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data TestStatus (Context)");
      context.TestStatuss.AddRange(DataTestStatus);
      context.SaveChanges();
    }
  }
  public static void SeedTestStatus(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data TestStatus (ModelBuilder)");
    builder.Entity<TestStatus>().HasData(DataTestStatus);
  }
  public static List<TestStatus> DataTestStatus = [
    new TestStatus
    {
      Id = 1,
      Title = "TestStatus 1",
      Desc = "TestStatus 1 Desc",
      Status = Status.Activate,
    },
    new TestStatus
    {
      Id = 2,
      Title = "TestStatus 2",
      Desc = "TestStatus 2 Desc",
      Status = Status.DeActivate,
    },
    new TestStatus
    {
      Id = 3,
      Title = "TestStatus 3",
      Desc = "TestStatus 3 Desc",
      Status = Status.None,
    }
];

}