using GLOB.Domain.Base;
using GLOB.Domain.Enums;
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
  [HttpGet("{Id:int}")]
  public async Task<IActionResult> Get(int Id, [FromQuery] List<string>? Include)
  {
    return await _Actionz.Getz(_repo, Id, Include);
  }

  [HttpGet()]
  public async Task<IActionResult> Gets([FromQuery] List<string>? Include)
  {
    return await _Actionz.Getsz(_repo, Include);
  }
  [HttpDelete("{Id:int}")]
  public async Task<IActionResult> Delete(int Id)
  {
    return await _Actionz.Deletez(_repo, _uowInfra, Id);
  }
  [HttpPatch("{Id:int}")]
  public async Task<IActionResult> Status(int Id, [FromBody] Status status)
  {
    return await _Actionz.Statusz(_repo, _uowInfra, Id, status);
  }
  
}