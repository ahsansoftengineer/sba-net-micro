using AutoMapper;
using GLOB.Apps.Common;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace GLOB.API.Controllers.Base;
public abstract class BaseController<TController, TEntity, DtoSearch, DtoResponse, DtoCreate>
  : AlphaController<TController>
    //where TEntity : class
    where TEntity : AlphaEntity
    where DtoSearch : class
    where DtoResponse : class
    where DtoCreate : class
    where TController : class
{
  protected IRepoGenericz<TEntity> Repo = null;
  public BaseController(ILogger<TController> logger, IMapper mapper, IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork)
  {

  }

  [HttpDelete("{id:int}")]
  public async Task<IActionResult> Delete(int id)
  {
    if (id < 1) return DeleteInvalid();

    var search = await Repo.Get(q => q.Id == id);
    if (search == null) return DeleteNull();

    try
    {
      await Repo.Delete(id);
      await UnitOfWork.Save();
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Delete));
    }
    return NoContent();
  }
}