using GLOB.API.Staticz;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
// Create, Read, Update, Delete, Status, Paginate, Options
public abstract partial class API_3_CRUD_SPO_Controller<TController, TEntity, TDtoSearch, TDtoCreate>
  : API_2_RDS_Controller<TController, TEntity>
  where TController : class
  where TEntity : class, IEntityAlpha, IEntityStatus
  where TDtoCreate : class
  where TDtoSearch : class, IDtoSearch
{
  public API_3_CRUD_SPO_Controller(IServiceProvider srvcProvider) : base(srvcProvider)
  {
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginate([FromBody] DtoPageReq<TDtoSearch?> req)
  {
    return await _Actionz.GetsPaginatez(_repo, req);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromBody] DtoPageReq<TDtoSearch?> req)
  {
    return await _Actionz.GetsPaginateOptionsz(_repo, req);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] TDtoCreate data)
  {
    try
    {
      var mapped = _mapper.Map<TEntity>(data);
      var entity = await _repo.Insert(mapped);
      await _uowInfra.Save();
      return _Res.CreatedAtAction(this, nameof(Get), entity);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] TDtoCreate data)
  {
    try
    {
      if (Id < 1) return _Res.NotFoundId(Id);
      
      var item = await _repo.Get(Id);

      if (item == null) return _Res.NotFoundId(Id);

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowInfra.Save();
      return NoContent();
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Update));
    }
  }

}