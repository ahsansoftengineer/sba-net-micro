using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class API_3_EntityIdStatusPaginationController<TController, TEntity, TDtoSearch, TDtoCreate>
  : API_2_EntityIdStatusController<TController, TEntity>
  where TController : class
  where TEntity : class, IEntityAlpha, IEntityStatus
  where TDtoCreate : class
  where TDtoSearch : class, IDtoSearch
{
  public API_3_EntityIdStatusPaginationController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
  }
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<TDtoSearch?> req)
  {
    try
    {
      var list = await _repo.GetsPaginate(req);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(GetsPaginate));
    }
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromQuery] DtoPageReq<TDtoSearch?> req)
  {
    try
    {
      var list = await _repo.GetsPaginateOptions(req);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(GetsPaginateOptions));
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] TDtoCreate data)
  {
    if (!ModelState.IsValid) return BadRequestz();
    try
    {
      var result = _mapper.Map<TEntity>(data);
      await _repo.Insert(result);
      await _uowInfra.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, [FromBody] TDtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return InvalidId();
    try
    {
      var item = await _repo.Get(id);

      if (item == null) return InvalidId();

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowInfra.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }

}