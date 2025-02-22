using GLOB.API.Config;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BaseController<TController, TEntity, DtoResponse>
{
 [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id, [FromQuery] List<string>? includes)
  {
    var single = await Repo.Get(id, includes);
    var result = single.ToBaseDtoSingle();
    return Ok(result);
  }
  [HttpGet()]
  public async Task<IActionResult> Gets([FromQuery] List<string>? includes)
  {
    try
    {
      var list = await Repo.Gets(includes: includes);
      var result = list.ToBaseVMMulti();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
  [HttpGet("[action]")]
  public async Task<IActionResult> Select()
  {
    try
    {
      var list = await Repo.Gets();
      var result  = list.ToBaseVMSelect();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Select));
    }
  }
}