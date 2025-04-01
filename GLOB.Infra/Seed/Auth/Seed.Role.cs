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
  public static async Task SeedRoleInfra(this RoleManager<IdentityRole> mngr)
  {
    if (!await mngr.Roles.AnyAsync())
    {
      foreach (var item in SeedDataRole<IdentityRole>())
      {
        await mngr.CreateAsync(item);
      }
    }
  }
  // public static async Task SeedRoleInfra(this DBCntxtIdentity context)
  // {
  //   if (!context.Roles.Any())
  //   {
  //     await context.Roles.Add(SeedDataRole<IdentityRole>());
  //     context.SaveChanges();
  //   }
  // }
  public static List<T> SeedDataRole<T>() where T : IdentityRole, new()
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