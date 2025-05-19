using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  [HttpGet]
  public IActionResult LoginMicrosoftRedirect(string returnUrl = "/")
  {
    return BaseLoginRedirect("Microsoft", "LoginMicrosoft", "Account", returnUrl);
  }

  [HttpGet]
  public async Task<IActionResult> LoginMicrosoft(string returnUrl = "/")
  {
    return await BaseLogin("Microsoft");
  }

  // Google login callback
  [HttpGet]
  public IActionResult LoginGoogleRedirect()
  {
    return BaseLoginRedirect("Google", "LoginGoogle", "Account", "/");
  }
  [HttpGet]
  public async Task<IActionResult> LoginGoogle()
  {
    return await BaseLogin("Google");
  }

  [HttpGet]
  public IActionResult LoginFacebookRedirect()
  {
    return BaseLoginRedirect("Facebook", "LoginFacebook", "Account", "/");
  }
  [HttpGet]
  public async Task<IActionResult> LoginFacebook([FromBody] ExternalAuthDto model)
  {
    return await BaseLogin("Facebook");
  }

  // Apple login callback
  [HttpGet]
  public IActionResult LoginAppleRedirect()
  {
    return BaseLoginRedirect("Apple", "LoginApple", "Account", "/");
  }
  [HttpGet]
  public async Task<IActionResult> LoginApple([FromBody] ExternalAuthDto model)
  {
    return await BaseLogin("Apple");
  }


  // Base Logins
  private IActionResult BaseLoginRedirect(string provider, string action, string controller, string returnUrl = "/")
  {
    var redirectUrl = Url.Action(action, controller, new { returnUrl });
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
    return Challenge(properties, provider);
  }
  private async Task<IActionResult> BaseLogin(string scheme)
  {
    var result = await HttpContext.AuthenticateAsync(scheme);
    if (!result.Succeeded) return Unauthorized();

    var claims = result.Principal.Claims.ToDictionary(c => c.Type, c => c.Value);
    return Ok(new { Provider = scheme, Claims = claims });
  }
}