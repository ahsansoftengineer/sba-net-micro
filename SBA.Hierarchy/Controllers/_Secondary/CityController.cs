using GLOB.API.Staticz;
using GLOB.Domain.Base;
using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers;
[Route("[controller]")]
[ApiController]
public class CityController : Project_RDS_Controller<CityController, City>
{
  public CityController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowProjectz.Citys;
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginate([FromBody] DtoRequestPage<CityDtoSearch?> req)
  {
    return await _Actionz.GetsPaginatez(_repo, req);
  }
  [HttpPost("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromBody] DtoRequestPage<CityDtoSearch?> req)
  {
    return await _Actionz.GetsPaginateOptionsz(_repo, req);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> Create([FromBody] CityDtoCreate data)
  {
    try
    {
      bool hasParent = _uowProjectz.States.AnyId(data.StateId);
      if(!hasParent) return _Res.BadRequestzId("StateId",data.StateId);

      var result = _mapper.Map<City>(data);
      var entity = await _repo.Insert(result);
      await _uowInfra.Save();
      return _Res.CreatedAtAction(this, nameof(Get), entity);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("[action]/{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] CityDtoCreate data)
  {
    try
    {
      if (Id < 1) return _Res.NotFoundId(Id);

      var item = await _repo.Get(q => q.Id == Id);
      if (item == null) return _Res.NotFoundId(Id);
      
      bool hasParent = _uowProjectz.States.AnyId(data.StateId);
      if(!hasParent) return _Res.BadRequestzId("StateId",data.StateId);

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