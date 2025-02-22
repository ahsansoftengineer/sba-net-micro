using GLOB.API.Config;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BaseController<TController, TEntity, DtoResponse>
{
 [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id, [FromQuery] List<string> includes = null)
  {
    var single = await Repo.Get(id, includes);
    var result = Mapper.Map<BaseDtoSingleRes<DtoResponse>>(single);
    return Ok(result);
  }
  [HttpGet()]
  public async Task<IActionResult> Gets([FromQuery] List<string> includes)
  {
    try
    {
      var list = await Repo.Gets(includes: includes);
      var result = Mapper.Map<BaseDtoMultiRes<BaseDtoSelect>>(list);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
  [HttpGet("Select")]
  public async Task<IActionResult> Select()
  {
    try
    {
      var list = (await Repo.Gets()).ToBaseDtoSelect();
      // var result = Mapper.Map<BaseDtoMultiRes<List<BaseDtoSelect>>>(list);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Select));
    }
  }
}