using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Infra.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SBA.Auth.Controllers;

public partial class RoleController 
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
    return _repo.ToList().ToExtVMList().Ok();
  }
  [HttpPost("{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _repo.FirstOrDefault(x => x.Id == Id);
    if (data == null) return _Res.NotFoundId(Id);

    return data.ToExtVMSingle().Ok();
  }
  // List, Group
  [HttpGet]
  public async Task<IActionResult> GetsLookup()
  {
    var result = await _repo.Select(x => new { x.Id, x.Name })
        .ToDictionaryAsync(x => x.Id, y =>  y.Name);
    return result.ToExtVMSingle().Ok();
  }

  // List, Filter By Ids
  [HttpPost]
  public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds<string> req)
  {
    try
    {
      var list = await _repo.Where(x => req.Ids.Contains(x.Id)).ToListAsync();
      return  list.ToExtVMList().Ok();
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(GetsByIds));
    }
  }
  [HttpPost]
  public async Task<IActionResult> GetsByIdsLookup([FromBody] DtoRequestGetByIds<string> req)
  {
    try
    {
      var list = await _repo
        .Select(x => new { x.Id, x.Name })
        .Where((x) => req.Ids.Contains(x.Id))
        .ToDictionaryAsync(x => x.Id, y =>  y.Name);
      return list.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(GetsByIdsLookup));
    }
  }
  [HttpPost]
  public async Task<IActionResult> GetsPaginate(DtoRequestPageNoInclude req)
  {
    var query = _repo
      .ToExtQueryFilter(req.Filter)
      .ToExtQueryOrderBy(req.Sort)
      .Select(x => new
      {
        x.Id,
        x.Name,
        x.Status,
        x.CreatedAt,
        x.UpdatedAt
      });

    var result = await query.ToExtPageReq(req);
    return result.Ok();
  }

  [HttpPost]
  public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<DtoSearch?> req)
  {
    var list = await _repo.ToExtVMPageOptionsNoTrack<InfraRole, string>(req);
    return list.Ok();
  }
}