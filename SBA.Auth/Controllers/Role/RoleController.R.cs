using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SBA.Auth.Controllers;

public partial class RoleController 
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
    return _Res.Ok(_repo.ToList().ToExtVMList());
  }
  [HttpPost("{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _repo.FirstOrDefault(x => x.Id == Id);
    if (data == null) return _Res.NotFoundId(Id);

    return _Res.Ok(data.ToExtVMSingle());
  }
  // List, Group
  [HttpGet]
  public async Task<IActionResult> GetsLookup()
  {
    var result = await _repo.Select(x => new { x.Id, x.Name })
        .ToDictionaryAsync(x => x.Id, y => new { y.Id, y.Name });
    return _Res.Ok(result);
  }

  // List, Filter By Ids
  [HttpPost]
  public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds<string> req)
  {
    try
    {
      var list = await _repo.Where(x => req.Ids.Contains(x.Id)).ToListAsync();
      var result = list.ToExtVMList();
      return _Res.Ok(result);
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
        .ToDictionaryAsync(x => x.Id, y => new { y.Id, y.Name });
      return _Res.Ok(list);
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
    return _Res.Ok(result);
  }

  [HttpPost]
  public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<DtoSearch?> req)
  {
    var list = await _repo.ToExtVMPageOptionsNoTrack<InfraRole, string>(req);
    return _Res.Ok(list);
  }
}