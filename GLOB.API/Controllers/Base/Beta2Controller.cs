using GLOB.Domain.Base;
using GLOB.Domain.Common;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BetaController<TController, TEntity, DtoSearch, DtoResponse, DtoCreate>
  //where TEntity : class
  where TEntity : BetaEntity
  where DtoSearch : class
  where DtoResponse : class
  where DtoCreate : class
  where TController : class
{

  [HttpGet]
  public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<TEntity, DtoSearch?> filter)
  {
    try
    {
      var list = await Repo.GetsPaginate(filter);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(GetsPaginate));
    }
  }
}