using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
    _logger.LogWarning("How does Type Works -> "+ this);
  }
//   [Authorize()]
  [HttpGet()]
  public async Task<IActionResult> Gets()
  {
    var list = _roleManager.Roles.ToList().ToExtResVMMulti();
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
  // [HttpGet("[action]")]
  // public async Task<IActionResult> GetsPaginate(DtoPageReq<InfraRoleDtoSearch> req)
  // {
  //   // var query = _roleManager.Roles.ToExtQueryFilter(req.Filter);
  //   // query = query.ToExtQueryOrderBy(req.Sort);
  //   // query = query.ToExtQueryInclues(req.Include);

  //   var query = _roleManager.Roles.ToExtQueryFilterSortInclude(req);
  //   var project = query.Select(x =>  new DtoRead<string>() {
  //     Id = x.Id,
  //     Name = x.Name,
  //     Status = x.Status,
  //     CreatedAt = x.CreatedAt,
  //     UpdatedAt = x.UpdatedAt
  //   });
  //   DtoPageResBase<DtoRead<string>> p = new()
  //   {
  //     PageNo = req.PageNo,
  //     PageSize = req.PageSize
  //   };
  //   var d = await project.ToExtQueryPage(p);

  //   var result = _roleManager.Roles.GetsPaginate(req);

  //   return Ok(d);
  // }
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
    if(role == null) return InvalidId();

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