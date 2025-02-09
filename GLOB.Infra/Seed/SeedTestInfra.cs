using GLOB.Domain.Base;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class Seederz
{
  public static void SeedTestInfra(this AppDBContextz context)
  {
    if (!context.TestInfras.Any(x => x.Id > 0))
    {
      context.TestInfras.AddRange(SeedDataBaseEntity<TestInfra>());
      context.SaveChanges();
    }
  }
  public static void SeedTestInfra(this ModelBuilder builder)
  {
    builder.Entity<TestInfra>().HasData(SeedDataBaseEntity<TestInfra>());
  }
  public static List<T> SeedDataBaseEntity<T>() where T : BaseEntity, new()
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();
    for (int i = 1; i <= 3; i++)
    {
      list.Add(new T()
      {
        Id = i,
        Title = $"{className} {i}",
        Desc = $"{className} {i} Desc",
      });
    }
    return list;
  }
}