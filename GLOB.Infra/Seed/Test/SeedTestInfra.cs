using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class Seeder
{
  public static void SeedTestInfra(this AppDBContextz context)
  {
    if (!context.TestInfras.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data TestInfra (Context)");
      context.TestInfras.AddRange(DataTestInfra);
      context.SaveChanges();
    }
  }
  public static void SeedTestInfra(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data TestInfra (ModelBuilder)");
    builder.Entity<TestInfra>().HasData(DataTestInfra);
  }
  public static List<TestInfra> DataTestInfra = [
    new TestInfra
    {
      Id = 1,
      Title = "TestInfra 1",
      Desc = "TestInfra 1 Desc",
    },
    new TestInfra
    {
      Id = 2,
      Title = "TestInfra 2",
      Desc = "TestInfra 2 Desc",
    },
    new TestInfra
    {
      Id = 3,
      Title = "TestInfra 3",
      Desc = "TestInfra 3 Desc",
    }
];

}