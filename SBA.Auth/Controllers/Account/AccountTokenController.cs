using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{

  [HttpPost()]
  public async Task<IActionResult> Login([FromBody] LoginDto model)
  {
    try
    {
      var user = await _userManager.FindByEmailAsync(model.Email);
      if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
      {
        var roles = await _userManager.GetRolesAsync(user);

        string jti = "";
        var accessToken = _tokenService.GenerateAccessToken(user, roles, out jti);
        var refreshToken = _tokenService.GenerateRefreshToken();


        var accessTokenExpiry = DateTime.UtcNow.AddMinutes(_jwtSettings.AccessTokenExpiryMinutes);
        var refreshTokenExpiry = DateTime.UtcNow.AddDays(_jwtSettings.RefreshTokenExpiryDays);

        string ip = HttpContext.Connection.RemoteIpAddress?.ToString();
        await _tokenService.SaveRefreshTokenAsync(user.Id, refreshToken, ip, jti);

        return Ok(new
        {
          accessToken,
          refreshToken,
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
            roles
          }
        });
      }

      return Unauthorized("Invalid credentials.");
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
      return StatusCode(500, "An error occurred during login.");
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