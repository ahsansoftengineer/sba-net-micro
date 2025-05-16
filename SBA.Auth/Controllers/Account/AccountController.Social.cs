using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class AccountController
{
  // Google login callback
  [HttpGet]
  public IActionResult LoginGoogleRedirect()
  {
    return BaseLoginRedirect("Google", "LoginGoogle", "Account", "/");
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
  [HttpGet]
  public IActionResult LoginMicrosoftRedirect(string returnUrl = "/")
  {
    var redirectUrl = Url.Action("LoginMicrosoft", "Account", new { returnUrl });
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
    return Challenge(properties, "Microsoft");
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

  public IActionResult BaseLoginRedirect(string provider, string action, string controller, string returnUrl = "/")
  {
    var redirectUrl = Url.Action(action, controller, new { returnUrl });
    var properties = new AuthenticationProperties { RedirectUri = redirectUrl };
    return Challenge(properties, provider);
  }

  [HttpGet("external-login-callback")]
  public async Task<IActionResult> BaseLogin(string returnUrl = "/")
  {
    var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    if (!result.Succeeded) return Unauthorized();

    var claims = result.Principal.Claims.ToDictionary(c => c.Type, c => c.Value);
    return Ok(new { Provider = result.Properties.Items[".AuthScheme"], Claims = claims });
  }
}