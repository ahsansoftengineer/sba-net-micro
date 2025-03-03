using GLOB.Domain.Auth;
using GLOB.Infra.Context.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class Seederz
{
  public static void SeedUserRole(this ModelBuilder mb)
  {
    // SeedDataUserRole<UserRole>()
    // mb.Entity<UserRole>().HasData();
    mb.Entity<IdentityRole>().HasData();
  }
  public static void SeedUserRole(this DBCntxtIdentity context)
  {
    if (!context.Roles.Any())
    {
      context.Roles.AddRange(SeedDataUserRole<IdentityRole>());
      context.SaveChanges();
    }
  }
  public static async Task SeedUserRole(this RoleManager<IdentityRole> mngr)
  {
    if(!await mngr.Roles.AnyAsync())
    {
      foreach(var item in SeedDataUserRole<IdentityRole>())
      {
        await mngr.CreateAsync(item);
      }
    }
    
  }
  public static List<T> SeedDataUserRole<T>() where T : IdentityRole, new()
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();

    for (int i = 1; i <= 3; i++)
    {
      string name = $"{className}_{i}";
      string NAME = name.ToUpper();
      var data = new T()
      {
        
        Id = Guid.NewGuid().ToString(),
        Name = name,
        NormalizedName = NAME
      };
      list.Add(data);
    }
    return list;
  }
}