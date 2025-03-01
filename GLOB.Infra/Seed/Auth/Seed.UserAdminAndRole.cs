using System.Security.Claims;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace GLOB.Infra.Seed;
public static partial class Seederz
{
  public static async Task SeedRolesAndAdmin(IServiceProvider srvc)
  {
    var roleManager = srvc.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = srvc.GetRequiredService<UserManager<UserInfra>>();

    foreach (var role in ROLE.ROLES)
    {
      if (!await roleManager.RoleExistsAsync(role))
      {
        await roleManager.CreateAsync(new IdentityRole(role));
      }
    }

    string email = $"admin@yopmail.com";
    var adminUser = await userManager.FindByEmailAsync(email);
    if (adminUser == null)
    {
      string normalized = email.ToUpper();
      var user = new UserInfra
      {

        Id = Guid.NewGuid().ToString(),
        UserName = email,
        Email = email,
        NormalizedUserName = normalized,
        NormalizedEmail = normalized,
        EmailConfirmed = true,
      };
      var createUser = await userManager.CreateAsync(user, "Admin@123");
      if (createUser.Succeeded)
      {
        await userManager.AddToRoleAsync(user, "Admin");
        await userManager.AddClaimAsync(user, new Claim("ManageUsers", "true"));
      }
    }
  }
}