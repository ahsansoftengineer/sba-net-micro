using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Domain.Contants;
using GLOB.Infra.Paginate;
using LinqKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SBA.Auth.Controllers;

public partial class RoleController
{
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] DtoCreate role)
  {
    if (!ModelState.IsValid) return _Res.BadRequestModel(ModelState);
    if (string.IsNullOrWhiteSpace(role.Name))
    {
      return _Res.BadRequestModel("Name", $"Invalid Role");
    }

    var exsist = await _roleManager.RoleExistsAsync(role.Name);
    if (exsist)
    {
      return _Res.BadRequestModel("Name", $"{role} already exsist");

    }

    var rolz = new InfraRole(role.Name);
    rolz.Status = GLOB.Domain.Enums.Status.None;
    rolz.Id = Constantz.Guidz();
    var result = await _roleManager.CreateAsync(rolz);
    if (result.Succeeded) return Ok(rolz.ToExtVMSingle());
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
    if (result.Succeeded) return Ok(role.ToExtVMSingle());
    result?.Errors?.ForEach(x =>
    {
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
  [HttpPatch("{Id}")]
  public async Task<IActionResult> Status(string Id, [FromBody] DtoRequestStatus req)
  {
    try
    {
      if (Id.IsNullOrEmpty()) return _Res.NotFoundId(Id);
      if (!Enum.IsDefined(req.Status)) return _Res.InvalidEnums(req.Status.ToString());

      var item = await _roleManager.FindByIdAsync(Id);

      if (item == null) return _Res.NotFoundId(Id);

      item.Status = req.Status;
      await _roleManager.UpdateAsync(item);
      await _uowProjectz.Save();
      return Ok(item);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Status));
    }
  }


  [HttpPost]
  public async Task<IActionResult> AddUserToRole([FromBody] AssignRoleToInfraUser dto)
  {
    var user = await _userManager.FindByEmailAsync(dto.Email);
    if (user == null)
      return _Res.BadRequestModel("Email", "Invalid Email not Exsist");

    var rolez = await _roleManager.FindByNameAsync(dto.Role);
    if (rolez == null)
      return _Res.BadRequestModel("Role", "Invalid Role not Exsist");

    // Check if user is already in role
    if (await _userManager.IsInRoleAsync(user, rolez.Name))
      return _Res.BadRequestModel("Role", $"{user.Email} is already assigned to role {rolez.Name}");

    var result = await _userManager.AddToRoleAsync(user, rolez.Name);
    if (result.Succeeded)
    {
      return _Res.Ok($"{user.Email} has successfully been added to role {rolez.Name}");
    }

    return _Res.BadRequestModel("Exception", "Something went wrong");
  }
  

}