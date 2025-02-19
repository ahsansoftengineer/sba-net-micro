using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BaseController<TController, TEntity, DtoResponse>
{
 [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id, [FromQuery] List<string> includes = null)
  {
    var single = await Repo.Get(id, includes);
    var result = Mapper.Map<BaseDtoSingle<DtoResponse>>(single);
    return Ok(result);
  }
  [HttpGet("GetAll")]
  public async Task<IActionResult> Gets([FromQuery] List<string> includes)
  {
    try
    {
      var list = await Repo.Gets(includes: includes);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
}