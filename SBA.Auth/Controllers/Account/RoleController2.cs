using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SBA.Auth.Controllers;

[Route("api/Auth/[controller]")]
public partial class RoleController : AlphaController<RoleController>
{
  [HttpPost()]
  public async Task<IActionResult> Create([FromBody] string role)
  {
    var exsist = await _roleManager.RoleExistsAsync(role);
    if (!exsist)
    {
      var rolz = new InfraRole(role);
      rolz.Id = Defaultz.Guidz();
      var result = await _roleManager.CreateAsync(rolz);
      if (result.Succeeded) return Ok(rolz.ToExtResVMSingle());
    }
    return BadRequest("Role already exist");
  }
  [HttpPut("{Id}")]
  public async Task<IActionResult> Update(string Id, [FromBody] DtoUpdate dto)
  {

    var role = await _roleManager.FindByIdAsync(Id);
    if (role == null) return InvalidId();

    role.Id = Id;
    role.Name = dto.Name;
    role.Status = dto.Status;

    var result = await _roleManager.UpdateAsync(role);
    if (result.Succeeded) return Ok(role.ToExtResVMSingle());

    return BadRequestz(result.Errors);
  }
  
  [HttpDelete("{Id}")]
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
  //   [HttpPost("[action]")]
  //   public async Task<IActionResult> AddUserToRole(string email, string role)
  //   {
  //     var user = await _userManager.FindByEmailAsync(email);
  //     if(user == null)
  //     {
  //       return BadRequest(new {
  //         error = "User does not exist"
  //       });
  //     }
  //     var rolez = await _roleManager.RoleExistsAsync(role);
  //     if(!rolez)
  //     {
  //       return BadRequest(new {
  //         error = "Role does not exist"
  //       });
  //     }

  //     var result = await _userManager.AddToRoleAsync(user, role);
  //     if(result.Succeeded)
  //     {
  //       return Ok();
  //     }
  //     else 
  //     {
  //       return BadRequest(new {
  //         error = "The user was not able to be added to the role"
  //       });
  //     }
  //   }
  //   public async Task<IActionResult> GetUserRoles(string email)
  //   {
  //     return null;
  //   }
}