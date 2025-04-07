using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
public partial class LoginController : AlphaController<LoginController>
{
  // private IRepoGenericz<AccountId> _repo = null;
  private readonly UserManager<InfraUser> _userManager;
  private readonly SignInManager<InfraUser> _signInManager;
  private IUOW uOW { get; }
  public LoginController(
    IServiceProvider srvcProvider,
    UserManager<InfraUser> userManager,
    SignInManager<InfraUser> signInManager
  ) : base(srvcProvider)
  {
    _userManager = userManager;
    _signInManager = signInManager;

  }
  [HttpPost()]
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
  public async Task<IActionResult> GoogleLogin([FromBody] ExternalAuthDto model)
  {
    return null;
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> FacebookLogin([FromBody] ExternalAuthDto model)
  {
    return null;
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> AppleLogin([FromBody] ExternalAuthDto model)
  {
    return null;
  }
}