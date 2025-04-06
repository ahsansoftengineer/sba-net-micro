using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;

[Route("api/Auth/[controller]")]
public partial class RoleController : AlphaController<RoleController>
{
  private readonly UserManager<InfraUser> _userManager;
  private readonly RoleManager<InfraRole> _roleManager;
  private IUOW uOW { get; }
  public RoleController(
    IServiceProvider srvcProvider,
    UserManager<InfraUser> userManager,
    RoleManager<InfraRole> roleManager
  ) : base(srvcProvider)
  {
    _userManager = userManager;
    _roleManager = roleManager;
    _logger.LogWarning("How does Type Works -> " + this);
  }

  //   [Authorize()]
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
    var result = data.ToExtResVMSingle();
    return Ok(result);
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate(DtoPageReq<InfraRoleDtoSearch?> req)
  {
    var query = _roleManager.Roles.ToExtQueryFilterSortInclude(req);
    var project = query.Select(x => new DtoRead<string>()
    {
      Id = x.Id,
      Name = x.Name,
      Status = x.Status,
      CreatedAt = x.CreatedAt,
      UpdatedAt = x.UpdatedAt
    });
    DtoPageResBase<DtoRead<string>> p = new()
    {
      PageNo = req.PageNo,
      PageSize = req.PageSize
    };
    var d = await project.ToExtPageRes(p);

    // var result = _roleManager.Roles.GetsPaginate(req);

    return Ok(d);
  }
}