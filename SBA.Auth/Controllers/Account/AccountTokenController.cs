using System.Security.Claims;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  [HttpPost("[action]")]
  public async Task<IActionResult> Login([FromBody] LoginDto model)
  {
    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
    {
      var roles = await _userManager.GetRolesAsync(user);
      var accessToken = _tokenService.GenerateAccessToken(user, roles);
      var refreshToken = _tokenService.GenerateRefreshToken();
      var refreshExpiry = DateTime.UtcNow.AddDays(7);

      await _tokenService.SaveRefreshTokenAsync(user.Id, refreshToken, refreshExpiry);

      return Ok(new
      {
        accessToken,
        refreshToken,
        expiresIn = 3600,
        tokenType = "Bearer",
        user = new
        {
          id = user.Id,
          username = user.UserName,
          email = user.Email,
          roles
        }
      });
    }
    return Unauthorized("Invalid credentials.");
  }

  [HttpPost("refresh-token")]
  public async Task<IActionResult> RefreshToken([FromBody] RefreshToken request)
  {
    var principal = _tokenService.GetPrincipalFromExpiredToken(request.Token);
    if (principal == null)
      return BadRequest("Invalid access token.");

    var userId = principal.FindFirstValue(ClaimTypes.NameIdentifier);
    var user = await _userManager.FindByIdAsync(userId);
    if (user == null)
      return BadRequest("User not found.");

    var storedToken = await _context.RefreshTokens
        .Where(rt => rt.UserId == userId && rt.Token == request.RefreshToken && !rt.IsRevoked && rt.ExpiresAt > DateTime.UtcNow)
        .FirstOrDefaultAsync();

    if (storedToken == null)
      return Unauthorized("Invalid or expired refresh token.");

    // Optional: revoke old token if using rotation
    storedToken.IsRevoked = true;

    var roles = await _userManager.GetRolesAsync(user);
    var newAccessToken = _tokenService.GenerateAccessToken(user, roles);
    var newRefreshToken = _tokenService.GenerateRefreshToken();
    var refreshExpiry = DateTime.UtcNow.AddDays(7);

    await _tokenService.SaveRefreshTokenAsync(user.Id, newRefreshToken, refreshExpiry);

    await _context.SaveChangesAsync();

    return Ok(new
    {
      accessToken = newAccessToken,
      refreshToken = newRefreshToken,
      expiresIn = 3600,
      tokenType = "Bearer"
    });
  }

}