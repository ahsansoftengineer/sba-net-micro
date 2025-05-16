using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  // Google login callback
  [HttpGet]
  public IActionResult LoginGoogleRedirect()
  {
    var redirectUrl = Url.Action("LoginGoogle", "Auth");
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
    return Challenge(properties, "Google");
  }
  [HttpGet]
  public async Task<IActionResult> LoginGoogle([FromBody] ExternalAuthDto model)
  {
    var result = await HttpContext.AuthenticateAsync("Google");

    if (result.Succeeded)
    {
      // Use result.Principal to extract claims and authenticate the user
      // return Ok(new { token = generatedJwtToken });
    }

    return Unauthorized();
  }

  [HttpGet]
  public IActionResult LoginFacebookRedirect()
  {
    var redirectUrl = Url.Action("LoginFacebook", "Auth");
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
    return Challenge(properties, "Facebook");
  }
  [HttpGet]
  public async Task<IActionResult> LoginFacebook([FromBody] ExternalAuthDto model)
  {
    var result = await HttpContext.AuthenticateAsync("Facebook");

    if (result.Succeeded)
    {
      // Handle login and create JWT
    }

    return Unauthorized();
  }

  // Apple login callback
  [HttpGet]
  public IActionResult LoginAppleRedirect()
  {
    var redirectUrl = Url.Action("LoginApple", "Auth");
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
    return Challenge(properties, "Apple");
  }
  [HttpGet]
  public async Task<IActionResult> LoginApple([FromBody] ExternalAuthDto model)
  {
    var result = await HttpContext.AuthenticateAsync("Apple");

    if (result.Succeeded)
    {
      // Handle login and create JWT
    }

    return Unauthorized();
  }
}