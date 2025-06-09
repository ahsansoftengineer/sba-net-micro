using GLOB.Infra.Enumz;
using GLOB.Hierarchy.Global;
using Microsoft.EntityFrameworkCore;
using SBA.Projectz.Data;

namespace GLOB.Projectz.Seed;
public static partial class Seeder
{
  public static void SeedGlobalLookup(this DBCtxProjectz context)
  {
    if (!context.GlobalLookups.Any(x => x.Id > 0))
    {
      context.GlobalLookups.AddRange(SeedDataGlobalLookup<GlobalLookup>());
      context.SaveChanges();
    }
  }
  public static void SeedGlobalLookup(this ModelBuilder builder)
  {
    builder.Entity<GlobalLookup>().HasData(SeedDataGlobalLookup<GlobalLookup>());
  }
  public static List<T> SeedDataGlobalLookup<T>() where T : GlobalLookup, new()
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
        GlobalLookupBaseId = i
      });
    }
    return list;
  }
  
}