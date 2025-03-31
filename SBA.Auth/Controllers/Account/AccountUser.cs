// using GLOB.API.Controllers.Base;
// using GLOB.Infra.Helper;
// using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Mvc;

// namespace SBA.Auth.Controllers;
// public partial class AccountController : AlphaController<AccountController>
// {
//   [Authorize()]
//   [HttpGet()]
//   public async Task<IActionResult> GetUsers()
//   {
//     var list = _userManager.Users.ToList();
//     var result = list.ToExtVMMulti();
//     return Ok(result);
//   }
//   [HttpGet("{id:int}")]
//   public async Task<IActionResult> GetUser(string Id)
//   {
//     var data = _userManager.Users.FirstOrDefault(x => x.Id == Id);
//     var result = data.ToExtVMSingle();
//     return Ok(data);
//   }
// }