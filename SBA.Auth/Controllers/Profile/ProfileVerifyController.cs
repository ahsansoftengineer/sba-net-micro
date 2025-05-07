// using GLOB.Domain.Auth;
// using Microsoft.AspNetCore.Mvc;

// namespace SBA.Auth.Controllers;

// public partial class ProfileController : AccountBaseController<ProfileController>
// {
//   public ProfileController(
//     IServiceProvider srvcProvider
//   ) : base(srvcProvider)
//   {
//   }

//   [HttpPost()]
//   public async Task<IActionResult> VerifyEmail([FromQuery] string token, [FromQuery] string email)
//   {
//     var user = await _userManager.FindByEmailAsync(email);
//     if (user == null)
//       return BadRequest(new { message = "Email not Found" });

//     var result = await _userManager.ConfirmEmailAsync(user, token);
//     return Ok(new { message = "Your Email has been verified" });
//   }

//   [HttpPost()]
//   public async Task<IActionResult> VerifyPhone([FromQuery] string token, [FromQuery] string email) 
//   {
//     var user = await _userManager.FindByEmailAsync(email);
//     if (user == null)
//       return BadRequest(new { message = "Email not Found" });

//     var result = await _userManager.ConfirmEmailAsync(user, token);
//     return Ok(new { message = "Your Email has been verified" });
//   }
// }