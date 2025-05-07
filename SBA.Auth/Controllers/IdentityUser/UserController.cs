using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SBA.Auth.Controllers;

public partial class UserController : AccountBaseController<UserController>
{
  private IQueryable<InfraUser> _repo;
  public UserController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _userManager.Users;
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> Gets()
  {
    var users = _repo.ToList();
    var result = _mapper.Map<List<InfraUserDtoRead>>(users).ToExtVMList();
    return Ok(result);
  }
  [HttpPost("[action]/{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _repo.FirstOrDefault(x => x.Id == Id);
    var result = _mapper.Map<InfraUserDtoRead>(data).ToExtVMSingle();
    return Ok(result);
  }
  // List, Group
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsLookup()
  {
    var result = await _repo.Select(x => new { x.Id, x.Name })
        .ToDictionaryAsync(x => x.Id, y => new { y.Id, y.Name });
    return _Actionz.Ok(result);
  }

  // List, Filter By Ids
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds<string> req)
  {
    try
    {
      var list = await _repo.Where(x => req.Ids.Contains(x.Id)).ToListAsync();
      var result = _mapper.Map<List<InfraUserDtoRead>>(list).ToExtVMList();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(GetsByIds));
    }
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsByIdsLookup([FromBody] DtoRequestGetByIds<string> req)
  {
    try
    {
      var list = await _repo
        .Select(x => new { x.Id, x.Name })
        .Where((x) => req.Ids.Contains(x.Id))
        .ToDictionaryAsync(x => x.Id, y => new { y.Id, y.Name });
      return _Actionz.Ok(list);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(GetsByIdsLookup));
    }
  }
  
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginate(DtoRequestPage<DtoSearch?> req)
  {
    var query = _repo
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
  public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<DtoSearch?> req)
  {
    var list = await _repo.ToExtVMPageOptionsNoTrack<InfraUser, string>(req);
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