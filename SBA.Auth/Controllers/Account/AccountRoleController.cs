using GLOB.API.Controllers.Base;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SBA.Auth.Controllers;
public partial class AccountController : AlphaController<AccountController>
{
  [Authorize()]
  [HttpGet()]
  public async Task<IActionResult> Gets()
  {
    var list = _roleManager.Roles.ToList();
    var result = list.ToExtVMMulti();
    return Ok(result);
  }
  [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _roleManager.Roles.FirstOrDefault(x => x.Id == Id);
    var result = data.ToExtVMSingle();
    return Ok(data);
  }

  [HttpPost()]
  public async Task<IActionResult> Create(string role)
  {
    var exsist = await _roleManager.RoleExistsAsync(role);
    if (!exsist)
    {
      var result = await _roleManager.CreateAsync(new IdentityRole(role));
      if (result.Succeeded) return Ok(result.ToExtVMSingle());
    }
    return BadRequest("Role already exist");
  }
  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(string Id, [FromBody] string text)
  {
    var role = await _roleManager.FindByIdAsync(Id);
    if (role != null)
    {
      role.Name = text;
      var result = await _roleManager.UpdateAsync(role);
      if (result.Succeeded) return Ok(result.ToExtVMSingle());
    }
    return BadRequest("Role already exist");
  }
  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(string Id)
  {
    if (Id.IsNullOrEmpty()) return InvalidId();

    var item = await _roleManager.FindByIdAsync(Id);
    if (item == null) return InvalidId();

    try
    {
      await _roleManager.DeleteAsync(item);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Delete));
    }
    return NoContent();
  }
}