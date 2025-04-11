using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using GLOB.Infra.Helper;
using GLOB.Infra.Repo;

namespace GLOB.API.Controllers.Base;
// Read, Delete, Status
public abstract partial class API_2_RDS_Controller<TController, TEntity>
  : API_1_ErrorController<TController>
    where TEntity : class, IEntityAlpha, IEntityStatus // (ID, Status)
    where TController : class
{

  protected virtual IRepoGenericz<TEntity> _repo {get; set;} // Will be initialize in Last Child Class
  public API_2_RDS_Controller(IServiceProvider srvcProvider) : base(srvcProvider)
  {

  } 
  [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id, [FromQuery] List<string>? Include)
  {
    try
    {
      var single = await _repo.Get(id, Include);
      var result = single.ToExtResVMSingle();
      return Ok(result);
    }
    catch(Exception ex)
    {
      return CatchException(ex, nameof(Get));
    }
    
  }
  [HttpGet()]
  public async Task<IActionResult> Gets([FromQuery] List<string>? Include)
  {
    try
    {
      var list = await _repo.Gets(Include: Include);
      var result = list.ToExtResVMList();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    try
    {
      if (id < 1) return Res_NotFoundDelete(id);
      var item = await _repo.Get(id);

      if (item == null) return Res_NotFoundDelete(id);
      await _repo.Delete(id);
      await _uowInfra.Save();
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Delete));
    }
    return Ok("Record Deleted Successfull");
  }
  [HttpPatch("{id:int}")]
  public async Task<IActionResult> Status(int id, [FromBody] Status status)
  {

    try
    {
      if (!ModelState.IsValid) return Res_NotFoundStatus(id);
      if(!Enum.IsDefined(status)) return Res_InvalidEnums(status.ToString());
      
      var item = await _repo.Get(id);

      if (item == null) return Res_NotFoundStatus(id);

      _repo.UpdateStatus(item, status);
      await _uowInfra.Save();
      return Ok(item);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Status));
    }
  }
  
}