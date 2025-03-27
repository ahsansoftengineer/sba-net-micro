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

  public async Task<IActionResult> AddUserToRole(string email, string role)
  {
    var user = await _userManager.FindByEmailAsync(email);
    if(user == null)
    {
      return BadRequest(new {
        error = "User does not exist"
      });
    }
    var rolez = await _roleManager.RoleExistsAsync(role);
    if(!rolez)
    {
      return BadRequest(new {
        error = "Role does not exist"
      });
    }

    var result = await _userManager.AddToRoleAsync(user, role);
    if(result.Succeeded)
    {
      return Ok();
    }
    else 
    {
      return BadRequest(new {
        error = "The user was not able to be added to the role"
      });
    }
  }
  public async Task<IActionResult> GetUserRoles(string email)
  {


    return null;
  }
}