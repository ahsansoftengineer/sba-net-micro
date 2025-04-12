using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using GLOB.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class InfraSeeder
{
  public static void SeedProjectzLookupzz(this DBCntxt context)
  {
    if (!context.ProjectzLookupzzs.Any(x => x.Id > 0))
    {
      context.ProjectzLookupzzs.AddRange(SeedDataProjectzLookupzz<ProjectzLookupzz>());
      context.SaveChanges();
    }
  }
  public static void SeedProjectzLookupzz(this ModelBuilder builder)
  {
    builder.Entity<ProjectzLookupzz>().HasData(SeedDataProjectzLookupzz<ProjectzLookupzz>());
  }
  public static List<T> SeedDataProjectzLookupzz<T>() where T : ProjectzLookupzz, new()
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
        ProjectzLookupzzBaseId = i
      });
    }
    return list;
  }
  
}