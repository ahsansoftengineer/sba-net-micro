using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract partial class BetaController<TController, TEntity, DtoSearch, DtoResponse, DtoCreate>
  : BaseController<TController, TEntity, DtoResponse>
  where TController : class
  where TEntity : class, IEntityAlpha
  where DtoCreate : class
  where DtoSearch : class
  where DtoResponse : class
{
  public BetaController(IServiceProvider srvcProvider) : base(srvcProvider)
  {

  }
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<DtoSearch?> req)
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

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] DtoCreate data)
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
  public async Task<IActionResult> Update(int id, [FromBody] DtoCreate data)
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