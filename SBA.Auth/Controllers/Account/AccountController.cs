using GLOB.Domain.Auth;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
public partial class AccountController : AccountBaseController<AccountController>
{
  // private IRepoGenericz<AccountId> _repo = null;
  public AccountController(
    IServiceProvider srvcProvider
  ) : base(srvcProvider)
  {
  }

  [HttpPost("[login]")]
  public async Task<IActionResult> Login([FromBody] LoginDto model)  
  {
    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
    {
        var token = HelperAuth.GenerateJwtToken(user, _config);
        return Ok(new { token });
    }
    return Unauthorized("Invalid credentials.");
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> Logout()  
  {
    await _signInManager.SignOutAsync();
    return Ok(new { message = "Logged out successfully" });
  }
  // [HttpPost("[action]")]
  // public async Task<IActionResult> Google([FromBody] ExternalAuthDto model)
  // {
  //   return null;
  // }
  // [HttpPost("[action]")]
  // public async Task<IActionResult> Facebook([FromBody] ExternalAuthDto model)
  // {
  //   return null;
  // }
  // [HttpPost("[action]")]
  // public async Task<IActionResult> Apple([FromBody] ExternalAuthDto model)
  // {
  //   return null;
  // }
}