using GLOB.Domain.Auth;
using GLOB.Infra.Data.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GLOB.Infra.Seed;
public static partial class InfraSeeder
{
  public static void SeedInfraUser(this ModelBuilder mb)
  {
    mb.Entity<InfraUser>().HasData(SeedDataInfraUser<InfraUser>());
  }
  public static async Task SeedInfraUser(this UserManager<InfraUser> mngr)
  {
    if (!await mngr.Users.AnyAsync())
    {
      foreach (var item in SeedDataInfraUser<InfraUser>())
      {
        await mngr.CreateAsync(item);
      }
    }
  }

  public static List<T> SeedDataInfraUser<T>() where T : IdentityUser<string>, new()
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();
    var passwordHasher = new PasswordHasher<T>();
    var guid = new []
    {
      "22c74fbc-9b0d-4848-85db-f09d58750006",
      "46eb923d-8529-4b77-b311-96e98ea6ea06",
      "8118fea8-a644-4d67-9eca-1d689465a1bf"
    };
    for (int i = 1; i <= 3; i++)
    {
      string name = $"{className}_{i}";
      string email = $"{name}@yopmail.com";
      string normalized = $"{name}@yopmail.com".ToUpperInvariant();
      var user = new T()
      {
        Id = guid[i-1],
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