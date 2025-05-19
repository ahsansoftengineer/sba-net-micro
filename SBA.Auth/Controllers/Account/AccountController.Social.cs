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
    return BaseLoginRedirect("Microsoft", "LoginMicrosoft", "Account", "/");
  }

  [HttpGet]
  public async Task<IActionResult> LoginMicrosoft(string returnUrl = "/")
  {
    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    if (!result.Succeeded)
      return Unauthorized();

    var claims = result.Principal.Claims.Select(c => new { c.Type, c.Value });
    return Ok(new { Provider = "Microsoft", Claims = claims });
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
    return BaseLoginRedirect("Facebook", "LoginFacebook", "Account", "/");
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
    return BaseLoginRedirect("Apple", "LoginApple", "Account", "/");
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



  // Base Logins
  private IActionResult BaseLoginRedirect(string provider, string action, string controller, string returnUrl = "/")
  {
    var redirectUrl = Url.Action(action, controller, new { returnUrl });
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
    return Challenge(properties, provider);
  }
  private async Task<IActionResult> BaseLogin(string returnUrl = "/")
  {
    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    if (!result.Succeeded) return Unauthorized();

    var claims = result.Principal.Claims.ToDictionary(c => c.Type, c => c.Value);
    return Ok(new { Provider = result.Properties.Items[".AuthScheme"], Claims = claims });
  }
}