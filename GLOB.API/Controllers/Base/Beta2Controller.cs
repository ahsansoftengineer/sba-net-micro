using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GLOB.API.Controllers.Base;
public abstract partial class BetaController<TController, TEntity, DtoSearch, DtoResponse, DtoCreate>
  //where TEntity : class
  where TEntity : BetaEntity
  where DtoSearch : class
  where DtoResponse : class
  where DtoCreate : class
  where TController : class
{

  // [HttpGet]
  // public async Task<IActionResult> GetsNonGeneric([FromQuery] PaginateRequestFilter<TEntity, DtoSearch?> filter)
  // {
  //   try
  //   {
  //     var list = Repo.GetDBSet()
  //       .Where(x => x.Id > 0)
  //       .OrderByDescending(b => b.UpdatedAt)
  //       .Skip(0)
  //       .Take(2)
  //       .ToListAsync();
  //     return Ok(list);
  //   }
  //   catch (Exception ex)
  //   {
  //     return CatchException(ex, nameof(Gets));
  //   }
  // }

  [HttpGet]
  public async Task<IActionResult> Gets([FromQuery] PaginateRequestFilter<TEntity, DtoSearch?> filter)
  {
    try
    {
      var list = await Repo.Gets();
      // var result = Mapper.Map<IPagedList<TEntity>, PaginateResponse<DtoResponse>>(list);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
}