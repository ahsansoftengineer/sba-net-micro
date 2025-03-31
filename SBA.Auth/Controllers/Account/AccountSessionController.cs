// using GLOB.API.Controllers.Base;
// using GLOB.Domain.Auth;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace SBA.Auth.Controllers;
// public partial class AccountController : AlphaController<AccountController>
// {
//   [HttpGet("me")]
//   [Authorize]
//   public async Task<IActionResult> GetCurrentUser()
//   {
//     return null;
//   }

//   [HttpGet("sessions")]
//   [Authorize]
//   public async Task<IActionResult> GetUserSessions()
//   {
//     return null;
//   }
//   [HttpDelete("sessions/{id}")]
//   [Authorize]
//   public async Task<IActionResult> RevokeSession(Guid id)
//   {
//     return null;
//   }

// }