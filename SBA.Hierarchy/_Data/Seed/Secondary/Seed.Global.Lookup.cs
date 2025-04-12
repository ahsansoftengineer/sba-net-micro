using GLOB.Domain.Enums;
using GLOB.Hierarchy.Global;
using Microsoft.EntityFrameworkCore;
using SBA.Projectz.Data;

namespace GLOB.Projectz.Seed;
public static partial class Seeder
{
  public static void SeedGlobalLookupzz(this ProjectzDBCntxt context)
  {
    if (!context.GlobalLookupzzs.Any(x => x.Id > 0))
    {
      context.GlobalLookupzzs.AddRange(SeedDataGlobalLookupzz<GlobalLookupzz>());
      context.SaveChanges();
    }
  }
  public static void SeedGlobalLookupzz(this ModelBuilder builder)
  {
    builder.Entity<GlobalLookupzz>().HasData(SeedDataGlobalLookupzz<GlobalLookupzz>());
  }
  public static List<T> SeedDataGlobalLookupzz<T>() where T : GlobalLookupzz, new()
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();
    for (int i = 1; i <= 3; i++)
    {
      list.Add(new T()
      {
        Id = i,
        Name = $"{className} {i}",
        Desc = $"{className} {i} Desc",
        Status = Status.None,
        Code = $"{i}{i}{i}-{i}{i}{i}-{i}{i}{i}",
        GlobalLookupzzBaseId = i
      });
    }
    return list;
  }
  
}