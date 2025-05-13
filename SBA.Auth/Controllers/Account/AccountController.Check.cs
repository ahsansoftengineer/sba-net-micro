using System.Security.Claims;
using GLOB.API.Config.DI;
using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  // [Authorize]
  [HttpPost]
  [Authorize(AuthenticationSchemes = "AuthorizationCookieScheme")]
  public async Task<IActionResult> CheckSchemeCookie()
  {
    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Current User Id {currentUserId} Cookie Based Token Working");
  }

  [HttpPost]
  [Authorize]
  public async Task<IActionResult> CheckLogin()
  {
    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Current User Id {currentUserId} Check Login");
  }

  [HttpPost]
  [Authorize(Policy = "Policy-Admin")]
  public async Task<IActionResult> CheckPolicyAdmin()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

    var roles = User.Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value);

    var rolez = string.Join(", ", roles);

    return _Res.Ok($"Id: {id}, IsAdmin: {User.IsInRole("Admin")}, Roles: {rolez}");
  }


  [HttpPost]
  [Authorize(Policy = "Policy-Customer")]
  public async Task<IActionResult> CheckPolicyCustomer()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

    var roles = User.Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value);

    var rolez = string.Join(", ", roles);

    return _Res.Ok($"Id: {id}, IsCustomer: {User.IsInRole("Customer")}, Roles: ({rolez})");
  }

  [HttpPost]
  [Authorize(Policy = "Policy-Admin--SuperAdmin")]
  public async Task<IActionResult> CheckPolicyMulti()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Policy Checks OK! (Admin Or Super Admin)");
  }

  [HttpPost]
  [Authorize(Roles = "Admin,Super Admin,Customer")] // ✅ Works: OR condition
  public async Task<IActionResult> CheckRoleOr()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Roles OK! (Admin | Super Admin | Customer) ");
  }

  [HttpPost]
  [Authorize(Roles = "Admin")]
  [Authorize(Roles = "Super Admin")] // ✅ Works: AND condition
  public async Task<IActionResult> CheckRoleAnd()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Roles OK! (Admin & Super Admin) ");
  }


 
}