using GLOB.Domain.Enums;
using GLOB.Hierarchy.Global;
using Microsoft.EntityFrameworkCore;
using SBA.Projectz.Data;

namespace GLOB.Infra.Seed;
public static partial class Seeder
{
  public static void SeedGlobalLookupz(this ProjectzDBCntxt context)
  {
    if (!context.GlobalLookupzs.Any(x => x.Id > 0))
    {
      context.GlobalLookupzs.AddRange(SeedDataGlobalLookupz<GlobalLookupz>());
      context.SaveChanges();
    }
  }
  public static void SeedGlobalLookupz(this ModelBuilder builder)
  {
    builder.Entity<GlobalLookupz>().HasData(SeedDataGlobalLookupz<GlobalLookupz>());
  }
  public static List<T> SeedDataGlobalLookupz<T>() where T : GlobalLookupz, new()
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
        GlobalLookupzBaseId = i
      });
    }
    return list;
  }
  
}