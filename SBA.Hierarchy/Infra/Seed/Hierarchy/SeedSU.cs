using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Infra;

namespace GLOB.Proj.Seed;
public static partial class Seeder
{
  public static void SeedSU(this AppDBContextProj context)
  {
    if (!context.SUs.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data SU (Context)");
      context.SUs.AddRange(DataSU);
      context.SaveChanges();
    }
  }
  public static void SeedSU(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data SU (ModelBuilder)");
    builder.Entity<SU>().HasData(DataSU);
  }
  public static List<SU> DataSU = [
    new SU
    {
      Id = 1,
      Title = "SU 1",
      Desc = "SU 1 Desc",
      OUId = 1,
    },
    new SU
    {
      Id = 2,
      Title = "SU 2",
      Desc = "SU 2 Desc",
      OUId = 2,
    },
    new SU
    {
      Id = 3,
      Title = "SU 3",
      Desc = "SU 3 Desc",
      OUId = 2,
    }
  ];

}