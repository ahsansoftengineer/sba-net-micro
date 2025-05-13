using System.Security.Claims;
using GLOB.API.Staticz;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  // Jwt -> ✅ Login
  [HttpPost] [Authorize]
  public async Task<IActionResult> CheckLogin()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Current User Id {id} Check Login");
  }

  // JWT -> ✅ Role OR
  [HttpPost] [Authorize(Roles = "Admin,Super Admin,Customer")]
  public async Task<IActionResult> CheckRoleOr()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Roles OK! (Admin | Super Admin | Customer) ");
  }

  // JWT -> ✅ Role And
  [HttpPost] [Authorize(Roles = "Admin")] [Authorize(Roles = "Super Admin")] 
  public async Task<IActionResult> CheckRoleAnd()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Roles OK! (Admin & Super Admin) ");
  }

  // JWT -> ✅ Policy-Admin
  [HttpPost] [Authorize(Policy = "Policy-Admin")]
  public async Task<IActionResult> CheckPolicyAdmin()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

    var roles = User.Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value);

    var rolez = string.Join(", ", roles);

    return _Res.Ok($"Id: {id}, IsAdmin: {User.IsInRole("Admin")}, Roles: (Policy-Admin)");
  }

  // JWT -> ✅ Policy-Customer
  [HttpPost] [Authorize(Policy = "Policy-Customer")]
  public async Task<IActionResult> CheckPolicyCustomer()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

    var roles = User.Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value);

    var rolez = string.Join(", ", roles);

    return _Res.Ok($"Id: {id}, IsCustomer: {User.IsInRole("Customer")}, Policy: (Policy-Customer)");
  }

  // JWT -> ✅ Policy Multi Or
  [HttpPost] [Authorize(Policy = "Policy-Admin--SuperAdmin")]
  public async Task<IActionResult> CheckPolicyMulti()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Policy Checks OK! (Admin Or Super Admin)");
  }

  // Cookie -> ✅ Login
  [HttpPost] [Authorize(AuthenticationSchemes = "AuthorizationCookieScheme")]
  public async Task<IActionResult> CheckSchemeCookie()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Current User Id {id} Cookie Based Token Working");
  }
  // Cookie -> ✅ Role Admin
  [HttpPost] [Authorize(AuthenticationSchemes = "AuthorizationCookieScheme", Roles = "Admin")]
  public async Task<IActionResult> CheckSchemeCookieAdmin()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id}, IsAdmin: {User.IsInRole("Admin")}, Scheme: Cookie, Role: Admin");
  }

 
}