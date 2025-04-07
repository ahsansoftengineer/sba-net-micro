using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
[ApiController]
public partial class ProfileController : AccountBaseController<AccountController>
{
  public ProfileController(
    IServiceProvider srvcProvider
  ) : base(srvcProvider)
  {
  }


  [HttpPost("[action]")]
  public async Task<IActionResult> Register([FromBody] RegisterDto model) 
  {
    if (!ModelState.IsValid) return BadRequestz();
    var user = UserController.MapUser(model);
    var result = await _userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
        return Ok(new { message = "User registered successfully!" });
    }

    return BadRequest(result.Errors);
  }


 
  // [HttpPost("[action]")]
  // public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)  
  // {
  //   var principal = _jwtTokenService.GetPrincipalFromExpiredToken(model.Token);
  //       if (principal == null)
  //           return null;

  //       var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //       var user = await _userManager.FindByIdAsync(userId);
  //       if (user == null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
  //           return null;

  //       var newAccessToken = _jwtTokenService.GenerateAccessToken(user);
  //       var newRefreshToken = _jwtTokenService.GenerateRefreshToken();
  //       user.RefreshToken = newRefreshToken;
  //       user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
  //       await _userManager.UpdateAsync(user);

  //       return new { AccessToken = newAccessToken, RefreshToken = newRefreshToken };  
  // }

  // [HttpPost("[action]")]
  // public async Task<IActionResult> VerifyEmail([FromQuery] string token, [FromQuery] string email) 
  // {
  //   var user = await _userManager.FindByEmailAsync(email);
  //   if (user == null)
  //     return BadRequest(new { message = "Email not Found" });

  //   var result = await _userManager.ConfirmEmailAsync(user, token);
  //   return Ok(new { message = "Your Email has been verified" });
  // }
}