using GLOB.API.Staticz;
using GLOB.Domain.Model.Auth;
using GLOB.Infra.Model.Base;
using GLOB.Domain.Contants;
using GLOB.Infra.Utils.Paginate.Extz;
using LinqKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace SBA.Auth.Controllers;

public partial class RoleController: AccountBaseController<RoleController>
{
  private readonly RoleManager<InfraRole> _roleManager;
  private readonly IQueryable<InfraRole> _repo;
  public RoleController(
    IServiceProvider srvcProvider,
    RoleManager<InfraRole> roleManager
  ) : base(srvcProvider)
  {
    _roleManager = roleManager;
    _repo = roleManager.Roles;
  }

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
    rolz.Status = GLOB.Infra.Enumz.Status.None;
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
    if (!result.Succeeded)
      return result?.Errors.BadRequestModel();

    return Ok(role.ToExtVMSingle());
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


}