using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

public partial class UserController : AccountBaseController<UserController>
{
  public UserController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
  }
  [HttpGet("[action]")]
  public async Task<IActionResult> Gets()
  {
    var users = _userManager.Users.ToList();
    var result = _mapper.Map<List<InfraUserDtoRead>>(users).ToExtVMList();
    return Ok(result);
  }
  [HttpGet("[action]/{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _userManager.Users.FirstOrDefault(x => x.Id == Id);
    var result = _mapper.Map<InfraUserDtoRead>(data).ToExtVMSingle();
    return Ok(result);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginate(DtoRequestPage<InfraUserDtoSearch?> req)
  {
    var query = _userManager.Users
      .ToExtQueryFilter(req.Filter)
      .ToExtQueryOrderBy(req.Sort)
      .Select(x => new {
        x.Id,
        x.Name, 
        x.Email,
        x.PhoneNumber,
        x.Status,
        x.CreatedAt,
        x.UpdatedAt
      });
   
    var result = await query.ToExtPageReq(req);
    return Ok(result);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<InfraUserDtoSearch?> req)
  {
    var list = await _userManager.Users.ToExtVMPageOptionsNoTrack<InfraUser, string, InfraUserDtoSearch>(req);
    return Ok(list);
  }

  // [HttpGet("[action]")]
  // public async Task<IActionResult> GetsPaginate(DtoRequestPage<InfraUserDtoSearch> req)
  // {
  //   var query = _userManager.Users.ToExtQueryFilterSortInclude(req);
  //   var mappedQuery = query.ToExtMapQuery<>()
  //   var result = query.GetsPaginateOptions<InfraUser, string, InfraUserDtoSearch>(req);
  //   return await result.GetsPaginate(req);
  // }

  // [HttpGet("[action]")]
  // public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<InfraUser> req)
  // {
  //   IQueryable<InfraUser> query = _userManager.Users;
  //   var result = query.ToExtQueryFilterSortInclude(req).GetsPaginateOptions<InfraUser, string>();
  //   return  Ok(result);
  // }

}