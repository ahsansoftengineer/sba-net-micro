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

  [HttpDelete("{Id:int}")]
  public async Task<IActionResult> Delete(int Id)
  {
    return await _repo.ToActionDelete(_uowInfra, Id);
  }
  [HttpPatch("{Id:int}")]
  public async Task<IActionResult> UpdateStatus(int Id, [FromBody] DtoRequestStatus dto)
  {
    return await _repo.ToActionStatus(_uowInfra, Id, dto.Status);
  }
  
}