using GLOB.API.Staticz;
using GLOB.Domain.Auth;
using GLOB.Infra.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SBA.Auth.Controllers;

public partial class UserController 
{
  [HttpPost]
  public async Task<IActionResult> Gets()
  {
    var users = _repo.ToList();
    var result = _mapper.Map<List<InfraUserDtoRead>>(users).ToExtVMList();
    return Ok(result);
  }
  [HttpPost("{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _repo.FirstOrDefault(x => x.Id == Id);
    var result = _mapper.Map<InfraUserDtoRead>(data).ToExtVMSingle();
    return Ok(result);
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
   
    var list = await _repo.Where(x => req.Ids.Contains(x.Id)).ToListAsync();
    var result = _mapper.Map<List<InfraUserDtoRead>>(list).ToExtVMList();
    return Ok(result);
  
  }
  [HttpPost]
  public async Task<IActionResult> GetsByIdsLookup([FromBody] DtoRequestGetByIds<string> req)
  {
   
    var list = await _repo
      .Select(x => new { x.Id, x.Name })
      .Where((x) => req.Ids.Contains(x.Id))
        .ToDictionaryAsync(x => x.Id, y =>  y.Name);
    return list.ToExtVMSingle().Ok();
   
  }
  
  [HttpPost]
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

  [HttpPost]
  public async Task<IActionResult> GetsPaginateOptions(DtoRequestPage<DtoSearch?> req)
  {
    var list = await _repo.ToExtVMPageOptionsNoTrack<InfraUser, string>(req);
    return Ok(list);
  }
}