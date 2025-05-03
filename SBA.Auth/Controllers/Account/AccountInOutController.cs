using GLOB.Domain.Auth;
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
        return  await Login(new (){ Email = model.Email, Password = model.Password });
    }

    return BadRequest(result.Errors);
  }
  
  [HttpPost("[action]")]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();
    return Ok(new { message = "Logged out successfully" });
  }

  public async Task<IActionResult> CheckLogin()
  {
    return null;
  }
  public async Task<IActionResult> CheckHasRole()
  {
    return null;
  }
  public async Task<IActionResult> CheckHasClaims()
  {
    return null;
  }
  public async Task<IActionResult> CheckHasPermission()
  {
    return null;
  }
}