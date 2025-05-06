using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SBA.Auth.Controllers;

public partial class UserController : AccountBaseController<UserController>
{
  
  [HttpPost("[action]")]
  public async Task<IActionResult> Create([FromBody] RegisterDto model)
  {
    InfraUser user = MapUser(model);
    var result = await _userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
      return Ok(new { message = "User registered successfully!" });
    }

    return BadRequest(result.Errors);
  }
  

  [HttpPut("[action]/{Id}")]
  public async Task<IActionResult> Update(string Id, [FromBody] UpdateUserDto data)
  {
    if (string.IsNullOrEmpty(Id)) return _Res.NotFoundId(Id);
    try
    {
      var item = await _userManager.FindByIdAsync(Id);

      if (item == null) return _Res.NotFoundId(Id);
      item.Name = data.FullName;
      item.PhoneNumber = data.PhoneNumber;

      var result = await _userManager.UpdateAsync(item);
      await _uowInfra.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Update));
    }
  }

  [HttpDelete("[action]/{Id}")]
  public async Task<IActionResult> Delete(string Id)
  {
    if (Id.IsNullOrEmpty()) return _Res.NotFoundId(Id);

    var item = await _userManager.FindByIdAsync(Id);
    if (item == null) return _Res.NotFoundId(Id);

    try
    {
      await _userManager.DeleteAsync(item);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Delete));
    }
    return NoContent();
  }
  [HttpPatch("[action]/{Id}")]
  public async Task<IActionResult> Status(string Id, [FromBody] DtoRequestStatus req)
  {
    try
    {
      if (Id.IsNullOrEmpty()) return _Res.NotFoundId(Id);
      if(!Enum.IsDefined(req.Status)) return _Res.InvalidEnums(req.Status.ToString());
      
      var item = await _userManager.FindByIdAsync(Id);

      if (item == null) return _Res.NotFoundId(Id);

      item.Status = req.Status;
      await _userManager.UpdateAsync(item);
      await _uowProjectz.Save();
      
      var result = _mapper.Map<InfraUserDtoRead>(item);
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Status));
    }
  }
  internal static InfraUser MapUser(RegisterDto model)
  {
    return new InfraUser
    {
      Id = Guid.NewGuid().ToString(),
      UserName = model.Email,
      Email = model.Email,
      PhoneNumber = model.PhoneNumber,
      Name = model.FullName
    };
  }
}