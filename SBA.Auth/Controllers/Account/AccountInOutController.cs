using GLOB.Domain.Auth;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController : AccountBaseController<AccountController>
{
  // private IRepoGenericz<AccountId> _repo = null;
  public AccountController(
    IServiceProvider srvcProvider
  ) : base(srvcProvider)
  {
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> Register([FromBody] RegisterDto model) 
  {
    var user = UserController.MapUser(model);
    var result = await _userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
        return Ok(new { message = "User registered successfully!" });
    }

    return BadRequest(result.Errors);
  }
  
  [HttpPost("[action]")]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();
    return Ok(new { message = "Logged out successfully" });
  }
}