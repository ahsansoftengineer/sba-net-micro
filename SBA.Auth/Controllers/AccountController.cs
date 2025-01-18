using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Auth.Model;

namespace SBA.Auth.Controllers;
[ApiController]
[Route("api/[controller]")]
public class AccountController : ControllerBase
{
  private readonly UserManager<IdentityUser> _userManager;
  private readonly SignInManager<IdentityUser> _signInManager;
  private readonly RoleManager<IdentityRole> _roleManager;

  public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _roleManager = roleManager;
  }

  // Account.Register
  [HttpPost("register")]
  public async Task<IActionResult> Register([FromBody] RegisterModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var user = new IdentityUser { UserName = model.Email, Email = model.Email };
    var result = await _userManager.CreateAsync(user, model.Password);

    if (!result.Succeeded)
      return BadRequest(result.Errors);

    return Ok("Registration successful");
  }

  // Account.Login
  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

    if (!result.Succeeded)
      return Unauthorized("Invalid login attempt");

    return Ok("Login successful");
  }

  // Account.Logout
  [HttpPost("logout")]
  public async Task<IActionResult> Logout()
  {
    await _signInManager.SignOutAsync();
    return Ok("Logout successful");
  }

  // Account.ForgotPassword
  [HttpPost("forgot-password")]
  public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
      return BadRequest("Invalid email address");

    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
    // Send token via email (implementation skipped)
    return Ok("Password reset token sent");
  }

  // Account.ResetPassword
  [HttpPost("reset-password")]
  public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user == null)
      return BadRequest("Invalid email address");

    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.NewPassword);

    if (!result.Succeeded)
      return BadRequest(result.Errors);

    return Ok("Password reset successful");
  }

  // Account.ChangePassword
  [HttpPost("change-password")]
  public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordModel model)
  {
    if (!ModelState.IsValid)
      return BadRequest(ModelState);

    var user = await _userManager.GetUserAsync(User);
    if (user == null)
      return Unauthorized();

    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

    if (!result.Succeeded)
      return BadRequest(result.Errors);

    return Ok("Password changed successfully");
  }

  // Account.ConfirmEmail
  [HttpGet("confirm-email")]
  public async Task<IActionResult> ConfirmEmail(string userId, string token)
  {
    var user = await _userManager.FindByIdAsync(userId);
    if (user == null)
      return BadRequest("Invalid user");

    var result = await _userManager.ConfirmEmailAsync(user, token);

    if (!result.Succeeded)
      return BadRequest(result.Errors);

    return Ok("Email confirmed successfully");
  }

  // Account.ResendEmailConfirmation
  [HttpPost("resend-email-confirmation")]
  public async Task<IActionResult> ResendEmailConfirmation([FromBody] ResendEmailConfirmationModel model)
  {
    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user == null || await _userManager.IsEmailConfirmedAsync(user))
      return BadRequest("Invalid request");

    var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
    // Send token via email (implementation skipped)

    return Ok("Email confirmation link resent");
  }

  // Account.ExternalLogin
  [HttpPost("external-login")]
  public IActionResult ExternalLogin(string provider, string returnUrl = null)
  {
    var redirectUrl = Url.Action("ExternalLoginCallback", "Account", new { returnUrl });
    var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
    return Challenge(properties, provider);
  }
}
