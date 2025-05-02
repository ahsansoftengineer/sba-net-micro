using System.Security.Claims;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  [HttpPost("[action]")]
  public async Task<IActionResult> Login([FromBody] LoginDto model)
  {
    try
    {
      var user = await _userManager.FindByEmailAsync(model.Email);
      if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
      {
        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = _tokenService.GenerateAccessToken(user, roles);
        var refreshToken = _tokenService.GenerateRefreshToken();

        string ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        await _tokenService.SaveRefreshTokenAsync(user.Id, refreshToken, ip);

        return Ok(new
        {
          accessToken,
          refreshToken,
          expiresIn = 3600,
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
            roles
          }
        });
      }
      return Unauthorized("Invalid credentials.");
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return Ok(ex.Message);
    }

  }

  // [HttpPost("refresh-token")]
  // public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
  // {
  //   var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
  //   if (principal == null)
  //     return BadRequest("Invalid access token.");

  //   var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
  //   var user = await _userManager.FindByIdAsync(userId);
  //   if (user == null)
  //     return BadRequest("User not found.");

  //   var storedToken = await dbcontext.RefreshTokens
  //       .Where(rt => rt.InfraUserId == userId
  //         && rt.Token == request.RefreshToken
  //         && !rt.IsRevoked && rt.ExpiresAt > DateTime.UtcNow)
  //       .FirstOrDefaultAsync();

  //   if (storedToken == null)
  //     return Unauthorized("Invalid or expired refresh token.");

  //   // Optional: revoke old token if using rotation
  //   storedToken.IsRevoked = true;

  //   var roles = await _userManager.GetRolesAsync(user);
  //   var newAccessToken = _tokenService.GenerateAccessToken(user, roles);
  //   var newRefreshToken = _tokenService.GenerateRefreshToken();
  //   var refreshExpiry = DateTime.UtcNow.AddDays(7);

  //   string ip = HttpContext.Connection.RemoteIpAddress?.ToString();

  //   await _tokenService.SaveRefreshTokenAsync(user.Id, newRefreshToken, ip);

  //   await _uowProjectz.Save();

  //   return Ok(new
  //   {
  //     accessToken = newAccessToken,
  //     refreshToken = newRefreshToken,
  //     expiresIn = 3600,
  //     tokenType = "Bearer"
  //   });
  // }
}