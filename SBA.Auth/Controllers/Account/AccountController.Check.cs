using System.Security.Claims;
using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
  [HttpPost]
  [Authorize(AuthenticationSchemes = "AuthorizationCookieScheme")]
  public async Task<IActionResult> CheckSchemeCookie()
  {
    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Current User Id {currentUserId} Cookie Based Token Working");
  }

  [HttpPost] [Authorize]
  public async Task<IActionResult> CheckLogin()
  {
    var currentUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Current User Id {currentUserId} Check Login");
  }

[HttpPost] [Authorize(Policy = "Policy-Admin")]
public async Task<IActionResult> CheckPolicyAdmin()
{
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    
    var roles = User.Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value);

    var rolez = string.Join(", ", roles);

    return _Res.Ok($"Id: {id}, IsAdmin: {User.IsInRole("Admin")}, Roles: {rolez}");
}


  [HttpPost] [Authorize(Policy = "Policy-Customer")]
  public async Task<IActionResult> CheckPolicyCustomer()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    
    var roles = User.Claims
        .Where(c => c.Type == ClaimTypes.Role)
        .Select(c => c.Value);

    var rolez = string.Join(", ", roles);

    return _Res.Ok($"Id: {id}, IsCustomer: {User.IsInRole("Customer")}, Roles: ({rolez})");
  }
  
  [HttpPost] [Authorize(Policy = "Policy-Admin--SuperAdmin")]
  public async Task<IActionResult> CheckPolicyMulti()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Policy Checks OK! (Admin Or Super Admin)");
  }

  [HttpPost] [Authorize(Roles = "Admin,Super Admin,Customer")]
  public async Task<IActionResult> CheckRole()
  {
    var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
    return _Res.Ok($"Id: {id} Multi Roles OK! (Admin,Super Admin,Customer) ");
  }

  

  private async Task<IActionResult> GenerateTokensAndUserClaims(InfraUser user)
  {
    var roles = await _userManager.GetRolesAsync(user);

    string jti;
    var accessToken = _tokenService.GenerateAccessToken(user, roles, out jti);
    var refreshToken = _tokenService.GenerateRefreshToken();



    var accessTokenExpiry = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiryMinutes);
    // var accessTokenExpiry = DateTime.UtcNow.AddHours(_jwtSettings.AccessTokenExpiryHour);
    var refreshTokenExpiry = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays);

    string ip = HttpContext.Connection.RemoteIpAddress?.ToString();
    await _tokenService.SaveRefreshTokenAsync(user.Id, refreshToken, ip, jti);

    return new
    {
      accessToken,
      refreshToken,
      // expiresIn = _jwtSettings.AccessTokenExpiryHour,
      expiresIn = _jwtSettings.AccessTokenExpiryMinutes,
      accessTokenExpiry = accessTokenExpiry.ToString("o"), // ISO 8601
      refreshTokenExpiry = refreshTokenExpiry.ToString("o"),
      tokenType = "Bearer",
      user = new
      {
        user.Id,
        user.UserName,
        user.Email,
        user.EmailConfirmed,
        user.PhoneNumber,
        user.PhoneNumberConfirmed,
        user.TwoFactorEnabled,
        jti,
        roles
      }
    }.ToExtVMSingle().Ok();
  }
}