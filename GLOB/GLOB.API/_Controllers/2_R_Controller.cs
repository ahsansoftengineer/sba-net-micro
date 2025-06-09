using GLOB.Infra.Base;
using Microsoft.AspNetCore.Mvc;
using GLOB.API.Staticz;
using GLOB.Common.API;

namespace GLOB.API.Controllers.Base;
// Single, List, Group
public abstract partial class API_2_RDS_Controller<TController, TEntity>
{

  // Single, Include
  [HttpPost("{Id:int}")]
  public async Task<IActionResult> Get(int Id, [FromBody] DtoRequestGet req)
  {
    
    return await _repo.ToActionGet(Id, req.Includes);
  }

  // List, Filter, Include
  [HttpPost] //[NoCache]
  public async Task<IActionResult> Gets([FromBody] DtoRequestGet req)
  {
    return await _repo.ToActionGets(req.Includes);
  }
  // List, Group
  [HttpGet] //[NoCache]
  public async Task<IActionResult> GetsLookup()
  {
    return await _repo.ToActionGetsLookup();
  }

  // List, Filter By Ids
  [HttpPost] //[NoCache]
  public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds req)
  {
    return await _repo.ToActionGetsByIds(req.Ids);
  }

  // List, Group, Filter By Ids
  [HttpPost] //[NoCache]
  public async Task<IActionResult> GetsByIdsLookup([FromBody] DtoRequestGetByIds req)
  {
    return await _repo.ToActionGetsByIdsLookup(req.Ids);
  }
  [HttpPost] //[NoCache]
  public async Task<IActionResult> GetsCSV([FromBody] DtoRequestGet req)
  {
    try
    {
      var rawData = await _repo.Gets(Include: req.Includes);
      return rawData.ToCsvFileResult(null, (sb) =>
      {
        sb.Replace("Id", "ID");
      });
    }
    catch (Exception ex)
    {
      return new BadRequestObjectResult(ex.Message);
    }
  }
}