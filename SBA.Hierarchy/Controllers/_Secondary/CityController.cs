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

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<CityDtoSearch?> req)
  {
    try
    {
      var data = await _repo.GetsPaginate(req);
      return Ok(data);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(GetsPaginate));
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CityDtoCreate data)
  {
    if (!ModelState.IsValid) return Res_BadRequestModel();
    try
    {
      bool hasParent = _uowProjectz.States.AnyId(data.StateId);
      if(!hasParent) return Res_BadRequestzId("StateId",data.StateId);

      var result = _mapper.Map<City>(data);
      var entity = await _repo.Insert(result);
      await _uowInfra.Save();
      return Res_CreatedAtAction(nameof(Get), entity);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] CityDtoCreate data)
  {
    try
    {
      if (Id < 1) return Res_NotFoundId(Id);
      if(!ModelState.IsValid) return Res_BadRequestModel();

      var item = await _repo.Get(q => q.Id == Id);
      if (item == null) return Res_NotFoundId(Id);
      
      bool hasParent = _uowProjectz.States.AnyId(data.StateId);
      if(!hasParent) return Res_BadRequestzId("StateId",data.StateId);

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowInfra.Save();
      return NoContent();
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}