using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;
public partial class AccountController
{
  [HttpPost("[action]")]
  [Authorize]
  public async Task<IActionResult> Enable2FA()
  {
    return null;
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> Verify2FA([FromBody] TwoFactorDto model)

  {
    return null;
  }
  [HttpPost("[action]")]
  [Authorize]
  public async Task<IActionResult> Disable2FA()
  {
    return null;
  }

}