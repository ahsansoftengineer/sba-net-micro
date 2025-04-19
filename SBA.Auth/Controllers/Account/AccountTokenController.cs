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
}