using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BaseController<TController, TEntity, DtoResponse>
{
 [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id, [FromQuery] List<string>? Include)
  {
    var single = await Repo.Get(id, Include);
    var result = single.ToExtVMSingle();
    return Ok(result);
  }
  [HttpGet()]
  public async Task<IActionResult> Gets([FromQuery] List<string>? Include)
  {
    try
    {
      var list = await Repo.Gets(Include: Include);
      var result = list.ToExtVMMulti();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
}