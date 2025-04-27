using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;
using GLOB.Infra.Repo;
using GLOB.API.Staticz;

namespace GLOB.API.Controllers.Base;
// Read, Delete, Status
public abstract partial class API_2_RDS_Controller<TController, TEntity>
  : API_1_ErrorController<TController>
    where TEntity : class, IEntityAlpha, IEntityStatus // (ID, Status)
    where TController : class
{

  // Single, Filter
  [HttpPost("[action]/{Id:int}")]
  public async Task<IActionResult> Get(int Id, [FromBody] DtoRequestGet req)
  {
    return await _repo.ToActionGet(Id, req.Includes);
  }

  // List, Filter
  [HttpPost("[action]")]
  public async Task<IActionResult> Gets([FromBody] DtoRequestGet req)
  {
    return await _repo.ToActionGets(req.Includes);
  }
  // List, Group
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsGroup()
  {
    return await _repo.ToActionGetsGroup();
  }

  // List, Filter By Ids
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds req)
  {
    return await _repo.ToActionGetsByIds(req.Ids);
  }

  // Group, Filter By Ids
  [HttpPost("[action]")]
  public async Task<IActionResult> GetByIdsGroup([FromBody] DtoRequestGetByIds req)
  {
    return await _repo.ToActionGetsByIdsGroup(req.Ids);
  }
}