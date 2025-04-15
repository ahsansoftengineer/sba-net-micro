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

  public static List<T> SeedDataInfraUser<T>() where T : InfraUser, new()
  // IdentityUser<string>
  {
    string className = typeof(T).Name;
    List<T> list = new List<T>();
    var guid = new []
    {
      "22c74fbc-9b0d-4848-85db-f09d58750006",
      "46eb923d-8529-4b77-b311-96e98ea6ea06",
      "8118fea8-a644-4d67-9eca-1d689465a1bf"
    };
    var passwords = new []
    {
      "AQAAAAIAAYagAAAAEACmShpP3LWgwsZwhZISwadM6d/EtzQ0WMkq/Bxig2P6XzeL4P2BJb+oC+rs6sFdJg==",
      "AQAAAAIAAYagAAAAEPB7kfoIF5a0f/xqp1pdXMQAYZtvzQ2n8fxgXEGhjOP1aXilANBvPkwwhBlpRry1AQ==",
      "AQAAAAIAAYagAAAAEGjg05pvktKMxHjB3nhkrG/ugiQvLkZVjwmu8gzE4+nH4XXwV90eyhEmGkrj9qFVBA=="
    };
    for (int i = 1; i <= 3; i++)
    {
      string name;
      string email;
      if(i == 1){
        email = "user@example.com";
        name = "user";
      } else {
        name = $"{className}_{i}";
        email = $"{name}@yopmail.com";
      }
      
      string normalized = email.ToUpperInvariant();
      var user = new T()
      {
        Id = guid[i-1],
        UserName = email,
        Name = name,
        Email = email,
        EmailConfirmed = true,
        PhoneNumber = $"0321282770{i-1}",
        PhoneNumberConfirmed = true,
        NormalizedUserName = normalized,
        NormalizedEmail = normalized,
        ConcurrencyStamp = guid[i-1],
        SecurityStamp = guid[i-1],
        PasswordHash = passwords[i-1]
      };
      // var passwordHasher = new PasswordHasher<T>();
      // user.PasswordHash = passwordHasher.HashPassword(user, $"{name}@123");
      list.Add(user);
    }
    return list;
  }
}