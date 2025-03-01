using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;
public partial class AccountController : AlphaController<AccountController>
{
  [HttpGet("roles")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> GetRoles()
  {
    return null;
  }

  [HttpPost("assign-role")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto model)
  {
    return null;
  }
  [HttpDelete("remove-role")]
  [Authorize(Roles = "Admin")]
  public async Task<IActionResult> RemoveRole([FromBody] RemoveRoleDto model)
  {
    return null;
  }

}