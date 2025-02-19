using AutoMapper;
using GLOB.Apps.Common;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BetaController<TController, TEntity, DtoSearch, DtoResponse, DtoCreate>
  : BaseController<TController, TEntity, DtoResponse>
  where TEntity : BetaEntity
  where DtoSearch : class
  where DtoResponse : class
  where DtoCreate : class
  where TController : class
{
  // protected new IRepoGenericz<TEntity> Repo = null;
  public BetaController(ILogger<TController> logger, IMapper mapper, IUnitOfWorkz unitOfWork) : 
    base(logger, mapper, unitOfWork)
  {

  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] DtoCreate data)
  {
    if (!ModelState.IsValid) return CreateInvalid();
    try
    {
      var result = Mapper.Map<TEntity>(data);
      await Repo.Insert(result);
      await UnitOfWork.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, [FromBody] DtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return UpdateInvalid();
    try
    {
      var item = await Repo.Get(id);

      if (item == null) return UpdateNull();

      var result = Mapper.Map(data, item);
      Repo.Update(item);
      await UnitOfWork.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }

}