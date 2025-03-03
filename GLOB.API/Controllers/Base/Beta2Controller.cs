using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BetaController<TController, TEntity, DtoSearch, DtoResponse, DtoCreate>
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