// using System.Net;
// using GLOB.API.Configz;
// using GLOB.API.Staticz;
// using GLOB.Domain.Auth;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace SBA.Auth.Controllers;

// public partial class ProfileController
// {
//   [HttpPost()]
//   public async Task<IActionResult> PasswordForgot([FromBody] ForgotPasswordDto model)
//   {
//     if (!ModelState.IsValid)
//       return BadRequest(ModelState);

//     var user = await _userManager.FindByEmailAsync(model.Email);
//     if (user == null || !await _userManager.IsEmailConfirmedAsync(user))
//       return Ok(new { message = "If the email exists, a reset link will be sent." });

//     var token = await _userManager.GeneratePasswordResetTokenAsync(user);
//     var encodedToken = WebUtility.UrlEncode(token);

//     string url = _config.GetWebUrl();
//     var resetLink = $"{url}/password-reset?email={model.Email}&token={encodedToken}";

//     await _emailSender.SendEmailAsync(user.Email, "Reset Password", $"Click <a href='{resetLink}'>here</a> to reset your password.");

//     return Ok(new { message = "Reset link sent to email." });
//   }

//   [HttpPost()]
//   public async Task<IActionResult> PasswordReset([FromBody] ResetPasswordDto model)
//   {
//     if (!ModelState.IsValid)
//       return BadRequest(ModelState);

//     var user = await _userManager.FindByEmailAsync(model.Email);
//     if (user == null)
//       return _Res.NotFoundId("Email", model.Email);

//     var result = await _userManager.ResetPasswordAsync(user, WebUtility.UrlDecode(model.Token), model.NewPassword);

//     if (result.Succeeded)
//       return Ok(new { message = "Password has been reset." });

//     return BadRequest(result.Errors);
//   }

//   [HttpPost()]
//   public async Task<IActionResult> PasswordChange([FromBody] ChangePasswordDto model)
//   {
//     if (model.NewPassword != model.ConfirmPassword)
//     {
//         return BadRequest("New password and confirm password do not match.");
//     }

//     var user = await _userManager.GetUserAsync(User);
//     if (user == null)
//     {
//         return Unauthorized();
//     }

//     var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
//     if (!result.Succeeded)
//     {
//         var errors = result.Errors.Select(e => e.Description);
//         return BadRequest(new { Errors = errors });
//     }

//     return Ok("Password changed successfully.");
//   }

// }