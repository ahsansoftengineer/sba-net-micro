using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using GLOB.Infra.Helper;
using GLOB.Infra.Repo;

namespace GLOB.API.Controllers.Base;
public abstract partial class BaseController<TController, TEntity, DtoResponse>
  : AlphaController<TController>
    where TEntity : class, IEntityAlpha 
    where TController : class
    where DtoResponse : class
{

  protected virtual IRepoGenericz<TEntity> _repo {get; set;} // Will be initialize in Last Child Class
  public BaseController(IServiceProvider srvcProvider) : base(srvcProvider)
  {

  } 
  [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id, [FromQuery] List<string>? Include)
  {
    var single = await _repo.Get(id, Include);
    var result = single.ToExtVMSingle();
    return Ok(result);
  }
  [HttpGet()]
  public async Task<IActionResult> Gets([FromQuery] List<string>? Include)
  {
    try
    {
      var list = await _repo.Gets(Include: Include);
      var result = list.ToExtVMMulti();
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
    if (id < 1) return InvalidId();

    var item = await _repo.Get(id);
    if (item == null) return InvalidId();

    try
    {
      await _repo.Delete(id);
      await _unitOfWork.Save();
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Delete));
    }
    return NoContent();
  }
  [HttpPatch("{id:int}")]
  public async Task<IActionResult> Status(int id, [FromBody] Status status)
  {
    if (!ModelState.IsValid) return BadRequestz();
    if(!Enum.IsDefined(status)) return InvalidStatus();
    try
    {
      var item = await _repo.Get(id);

      if (item == null) return InvalidId();

      _repo.UpdateStatus(item, status);
      await _unitOfWork.Save();
      return Ok(item);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Status));
    }
  }
  
}