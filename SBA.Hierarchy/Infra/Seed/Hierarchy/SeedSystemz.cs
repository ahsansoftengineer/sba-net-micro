using GLOB.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using SBA.Hierarchy.Infra;

namespace GLOB.Proj.Seed;
public static partial class Seeder
{
  public static void SeedSystemz(this AppDBContextProj context)
  {
    if (!context.Systemzs.Any(x => x.Id > 0))
    {
      Console.WriteLine("--> Seeding Data Systemz (Context)");
      context.Systemzs.AddRange(DataSystemz);
      context.SaveChanges();
    }
  }
  public static void SeedSystemz(this ModelBuilder builder)
  {
    Console.WriteLine("--> Seeding Data Systemz (ModelBuilder)");
    builder.Entity<Systemz>().HasData(DataSystemz);
  }
  public static List<Systemz> DataSystemz = [
    new Systemz
    {
      Id = 1,
      Title = "Systemz 1",
      Desc = "Systemz 1 Desc",
      OrgId = 1,
    },
    new Systemz
    {
      Id = 2,
      Title = "Systemz 2",
      Desc = "Systemz 2 Desc",
      OrgId = 2,
    },
    new Systemz
    {
      Id = 3,
      Title = "Systemz 3",
      Desc = "Systemz 3 Desc",
      OrgId = 2,
    }
  ];

}