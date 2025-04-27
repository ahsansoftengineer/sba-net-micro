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

  public API_2_RDS_Controller(IServiceProvider srvcProvider) : base(srvcProvider)
  {

  } 
  protected virtual IRepoGenericz<TEntity> _repo {get; set;} // Will be initialize in Last Child Class

  [HttpPost("[action]/{Id:int}")]
  public async Task<IActionResult> Get(int Id, [FromBody] DtoRequestGet req)
  {
    return await _Actionz.Getz(_repo, Id, req.Includes);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> Gets([FromBody] DtoRequestGet req)
  {
    return await _Actionz.Getsz(_repo, req.Includes);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> GetsByIds([FromBody] DtoRequestGetByIds req)
  {
    return await _Actionz.GetsByIdsz(_repo, req.Ids);
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsByIdsGroup([FromBody] DtoRequestGetByIds req)
  {
    return await _Actionz.GetsByIdsz(_repo, req.Ids);
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsGroup([FromBody] DtoRequestGetByIds req)
  {
    return await _Actionz.GetsByIdsz(_repo, req.Ids);
  }

  [HttpDelete("[action]/{Id:int}")]
  public async Task<IActionResult> Delete(int Id)
  {
    return await _Actionz.Deletez(_repo, _uowInfra, Id);
  }
  [HttpPatch("[action]/{Id:int}")]
  public async Task<IActionResult> Status(int Id, [FromBody] DtoRequestStatus req)
  {
    return await _Actionz.Statusz(_repo, _uowInfra, Id, req.Status);
  }
  
}