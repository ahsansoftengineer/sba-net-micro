using GLOB.Domain.Base;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class InfraSeeder
{
  public static void SeedProjectzEntityLookup(this DBCntxt context)
  {
    if (!context.ProjectzEntityLookups.Any(x => x.Id > 0))
    {
      context.ProjectzEntityLookups.AddRange(SeedDataProjectzEntityLookup<ProjectzEntityLookup>());
      context.SaveChanges();
    }
  }
  public static void SeedProjectzEntityLookup(this ModelBuilder builder)
  {
    builder.Entity<ProjectzEntityLookup>().HasData(SeedDataProjectzEntityLookup<ProjectzEntityLookup>());
  }
  public static List<T> SeedDataProjectzEntityLookup<T>() where T : ProjectzEntityLookup, new()
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
        ProjectzEntityLookupBaseId = i
      });
    }
    return list;
  }
  
}