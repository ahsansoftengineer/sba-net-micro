using GLOB.Domain.Base;
using GLOB.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BetaController<TController, TEntity, DtoSearch, DtoResponse, DtoCreate>
  where TEntity : BaseEntity
  where DtoSearch : class
  where DtoResponse : class
  where DtoCreate : class
  where TController : class
{

  [HttpGet("GetsPaginate")]
  public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<TEntity, DtoSearch?> req)
  {
    try
    {
      var list = await Repo.GetsPaginate(req);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(GetsPaginate));
    }
  }
}