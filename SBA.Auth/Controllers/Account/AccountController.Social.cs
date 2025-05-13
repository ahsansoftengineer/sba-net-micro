using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  
  [HttpPost]
  public async Task<IActionResult> LoginGoogle([FromBody] ExternalAuthDto model)
  {
    return null;
  }
  [HttpPost]
  public async Task<IActionResult> LoginFacebook([FromBody] ExternalAuthDto model)
  {
    return null;
  }
  [HttpPost]
  public async Task<IActionResult> LoginApple([FromBody] ExternalAuthDto model)
  {
    return null;
  }
}