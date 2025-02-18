using AutoMapper;
using GLOB.Apps.Common;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract class BaseController<TController, TEntity>
  : AlphaController<TController>
    // where TEntity : class
    where TEntity : BetaEntity
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

    var item = await Repo.Get(id);
    if (item == null) return DeleteNull();

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