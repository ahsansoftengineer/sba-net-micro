using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Infra;

namespace GLOB.Proj.Seed;
public static partial class Seeder
{
  public static void SeedLE(this AppDBContextProj context)
  {
    if (!context.LEs.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data LE (Context)");
      context.LEs.AddRange(DataLE);
      context.SaveChanges();
    }
  }
  public static void SeedLE(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data LE (ModelBuilder)");
    builder.Entity<LE>().HasData(DataLE);
  }
  public static List<LE> DataLE = [
    new LE
    {
      Id = 1,
      Title = "LE 1",
      Desc = "LE 1 Desc",
      BGId = 1,
    },
    new LE
    {
      Id = 2,
      Title = "LE 2",
      Desc = "LE 2 Desc",
      BGId = 1,
    },
    new LE
    {
      Id = 3,
      Title = "LE 3",
      Desc = "LE 3 Desc",
      BGId = 3,
    }
  ];

}