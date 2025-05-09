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

  [HttpPost]
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
  
  [HttpPost]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();
    return Ok(new { message = "Logged out successfully" });
  }
  [HttpPost]
  public async Task<IActionResult> CheckLogin()
  {
    return null;
  }
  [HttpPost]
  public async Task<IActionResult> CheckHasRole()
  {
    return null;
  }
  [HttpPost]
  public async Task<IActionResult> CheckHasClaims()
  {
    return null;
  }
  [HttpPost]
  public async Task<IActionResult> CheckHasPermission()
  {
    return null;
  }
}