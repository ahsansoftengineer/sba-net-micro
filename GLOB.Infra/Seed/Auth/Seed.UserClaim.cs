using System.Security.Claims;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seed;
public static partial class Seederz
{
  public static async Task SeedRoleClaims(IServiceProvider serviceProvider)
  {
    var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var rolesWithClaims = new Dictionary<string, List<string>>
    {
        { "Admin", new List<string> { "CanEditUsers", "CanDeleteUsers", "CanViewReports" } },
    };

    foreach (var role in rolesWithClaims)
    {
      var existingRole = await roleManager.FindByNameAsync(role.Key);
      if (existingRole == null)
      {
        await roleManager.CreateAsync(new IdentityRole(role.Key));
        existingRole = await roleManager.FindByNameAsync(role.Key);
      }

      foreach (var claim in role.Value)
      {
        if (!(await roleManager.GetClaimsAsync(existingRole)).Any(c => c.Type == "Permission" && c.Value == claim))
        {
          await roleManager.AddClaimAsync(existingRole, new Claim("Permission", claim));
        }
      }
    }
  }

  public static async Task SeedUserClaim(this UserManager<IdentityUser> mngr)
  {
    if (!await mngr.Users.AnyAsync())
    {
      foreach (var item in SeedDataUserPermission<UserInfra>())
      {
        await mngr.CreateAsync(item);
      }
    }

  }
  public static List<T> SeedDataUserClaim<T>() where T : Claim, new()
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
        Properties = "",
        Subject = "",

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