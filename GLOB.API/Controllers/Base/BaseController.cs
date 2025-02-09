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

  [HttpGet]
  public async Task<IActionResult> Gets([FromQuery] PaginateRequestFilter<TEntity, DtoSearch?> filter)
  {
    try
    {
      var list = await Repo.GetsPaginate(filter);
      var result = Mapper.Map<IPagedList<TEntity>, PaginateResponse<DtoResponse>>(list);
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }

  [HttpGet("{id:int}")]
  public async Task<IActionResult> Get(int id)
  {
    var single = await Repo.Get(
      q => q.Id == id
     //, new List<string> { "Org" }
     );
    var result = Mapper.Map<BaseDtoSingle<DtoResponse>>(single);
    return Ok(result);
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
      var item = await Repo.Get(q => q.Id == id);

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