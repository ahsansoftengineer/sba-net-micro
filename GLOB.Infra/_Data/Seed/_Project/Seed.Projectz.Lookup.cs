using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class InfraSeeder
{
  public static void SeedProjectzLookupz(this DBCntxt context)
  {
    if (!context.ProjectzLookupzs.Any(x => x.Id > 0))
    {
      context.ProjectzLookupzs.AddRange(SeedDataProjectzLookupz<ProjectzLookupz>());
      context.SaveChanges();
    }
  }
  public static void SeedProjectzLookupz(this ModelBuilder builder)
  {
    builder.Entity<ProjectzLookupz>().HasData(SeedDataProjectzLookupz<ProjectzLookupz>());
  }
  public static List<T> SeedDataProjectzLookupz<T>() where T : ProjectzLookupz, new()
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
        ProjectzLookupzBaseId = i
      });
    }
    return list;
  }
  
}