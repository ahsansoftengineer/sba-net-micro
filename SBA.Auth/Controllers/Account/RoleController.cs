using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

[Route("[controller]")]
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

  [HttpGet()]
  public async Task<IActionResult> Gets()
  {
    var list = _roleManager.Roles.ToList().ToExtResVMList();
    return Ok(list);
  }
  [HttpGet("{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    Console.WriteLine("ID = " + Id);
    var data = _roleManager.Roles.FirstOrDefault(x => x.Id == Id);
    if(data == null) return _Res.NotFoundId(Id);
    var result = data.ToExtResVMSingle();
    return Ok(result);
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate(DtoPageReq<InfraRoleDtoSearch?> req)
  {
    var query = _roleManager.Roles
      .ToExtQueryFilterSortInclude(req)
      .Select(x => new {
        x.Id,
        x.Name, 
        x.Status,
        x.CreatedAt,
        x.UpdatedAt
      });
   
    var result = await query.ToExtPageRes(req);
    return Ok(result);
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginateOptions(DtoPageReq<InfraRoleDtoSearch?> req)
  {
    var list = await _roleManager.Roles.GetsPaginateOptions<InfraRole, string, InfraRoleDtoSearch>(req);
    return Ok(list);
  }
}