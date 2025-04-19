using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class RoleController : AccountBaseController<RoleController>
{
  private readonly RoleManager<InfraRole> _roleManager;
  public RoleController(
    IServiceProvider srvcProvider,
    RoleManager<InfraRole> roleManager
  ) : base(srvcProvider)
  {
    _roleManager = roleManager;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> Gets()
  {
    var list = _roleManager.Roles.ToList();
    return Ok(list);
  }
  [HttpGet("[action]/{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    Console.WriteLine("ID = " + Id);
    var data = _roleManager.Roles.FirstOrDefault(x => x.Id == Id);
    if(data == null) return _Res.NotFoundId(Id);
    var result = data.ToExtVMSingle();
    return Ok(result);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginate(DtoRequestPageNoInclude<InfraRoleDtoSearch?> req)
  {
    var query = _roleManager.Roles
      .ToExtQueryFilter(req.Filter)
      .ToExtQueryOrderBy(req.Sort)
      .Select(x => new {
        x.Id,
        x.Name, 
        x.Status,
        x.CreatedAt,
        x.UpdatedAt
      });
   
    var result = await query.ToExtPageReq(req);
    return Ok(result);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<InfraRoleDtoSearch?> req)
  {
    var list = await _roleManager.Roles.ToExtVMPageOptionsNoTrack<InfraRole, string, InfraRoleDtoSearch>(req);
    return Ok(list);
  }
}