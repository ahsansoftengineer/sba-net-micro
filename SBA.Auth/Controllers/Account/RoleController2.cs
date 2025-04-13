using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Domain.Contants;
using GLOB.Infra.Helper;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SBA.Auth.Controllers;

public partial class RoleController
{
  [HttpPost()]
  public async Task<IActionResult> Create([FromBody] string role)
  {
    var exsist = await _roleManager.RoleExistsAsync(role);
    if (!exsist)
    {
      var rolz = new InfraRole(role);
      rolz.Id = Constantz.Guidz();
      var result = await _roleManager.CreateAsync(rolz);
      if (result.Succeeded) return Ok(rolz.ToExtResVMSingle());
    }
    ModelState.AddModelError("Name", $"{role} already exsist");
    return _Res.BadRequestModel(ModelState);
  }
  [HttpPut("{Id}")]
  public async Task<IActionResult> Update(string Id, [FromBody] DtoUpdate dto)
  {

    var role = await _roleManager.FindByIdAsync(Id);
    if (role == null) return _Res.NotFoundId(Id);

    role.Id = Id;
    role.Name = dto.Name;
    role.Status = dto.Status;

    var result = await _roleManager.UpdateAsync(role);
    if (result.Succeeded) return Ok(role.ToExtResVMSingle());
    result?.Errors?.ForEach(x => {
      ModelState.AddModelError(x.Code, x.Description);
    });
    return _Res.BadRequestModel(ModelState);
  }
  
  [HttpDelete("{Id}")]
  public async Task<IActionResult> Delete(string Id)
  {
    if (Id.IsNullOrEmpty()) return _Res.NotFoundId(Id);

    var item = await _roleManager.FindByIdAsync(Id);
    if (item == null) return _Res.NotFoundId(Id);

    try
    {
      await _roleManager.DeleteAsync(item);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Delete));
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