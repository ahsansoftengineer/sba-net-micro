using GLOB.Domain.Auth;
using GLOB.Infra.Context.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class Seederz
{
  public static async Task SeedUserInfra(this UserManager<IdentityUser> mngr)
  {
    if(!await mngr.Users.AnyAsync())
    {
      foreach(var z in SeedDataUserInfra<UserInfra>())
      {
        await mngr.CreateAsync(z);
      }
    }
  }
  public static async Task SeedUserInfra(this DBCntxtIdentity context)
  {
    if (!context.Users.Any())
    {
      await context.Users.AddRangeAsync(SeedDataUserInfra<UserInfra>());
      context.SaveChanges();
    }
  }
  public static void SeedUserInfra(this ModelBuilder builder)
  {
    builder.Entity<UserInfra>().HasData(SeedDataUserInfra<UserInfra>());
  }

  public static List<T> SeedDataUserInfra<T>() where T : IdentityUser, new()
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();
    var passwordHasher = new PasswordHasher<T>();

    for (int i = 1; i <= 3; i++)
    {
      string name = $"{className}_{i}";
      string email = $"{name}@yopmail.com";
      string normalized = $"{name}@yopmail.com".ToUpper();
      var user = new T()
      {
        
        Id = Guid.NewGuid().ToString(),
        UserName = email,
        Email = email,
        NormalizedUserName = normalized,
        NormalizedEmail = normalized,
        EmailConfirmed = true,
      };
      user.PasswordHash = passwordHasher.HashPassword(user, $"{name}@123");
      list.Add(user);
    }
    return list;
  }
}