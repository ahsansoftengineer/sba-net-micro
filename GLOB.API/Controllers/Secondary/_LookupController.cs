using GLOB.API.Controllers.Base;
using GLOB.API.Staticz;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Projectz.Controllers;
[Route("[controller]")]
[ApiController]
public class _ProjectzLookupzController : API_2_RDS_Controller<_ProjectzLookupzController, ProjectzLookupzz>
{
  public _ProjectzLookupzController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookupzzs;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<ProjectzLookupzzDtoSearch?> req)
  {
    return await _Actionz.GetsPaginatez(_repo, req);
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromQuery] DtoPageReq<ProjectzLookupzzDtoSearch?> req)
  {
    return await _Actionz.GetsPaginateOptionsz(_repo, req);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] ProjectzLookupzzDtoCreate data)
  {
    try
    {
      bool hasParent = _uowInfra.ProjectzLookupzzBases.AnyId(data.ProjectzLookupzzBaseId);
      if(!hasParent) return _Res.BadRequestzId("ProjectzLookupzzBaseId",data.ProjectzLookupzzBaseId);

      var result = _mapper.Map<ProjectzLookupzz>(data);
      var entity = await _repo.Insert(result);
      await _uowInfra.Save();
      return _Res.CreatedAtAction(this, nameof(Get), entity);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] ProjectzLookupzzDtoCreate data)
  {
    try
    {
      if(Id < 1) return _Res.NotFoundId(Id);

      var item = await _repo.Get(q => q.Id == Id);
      if (item == null) return _Res.NotFoundId(Id);
      
      bool hasParent = _uowInfra.ProjectzLookupzzBases.AnyId(data.ProjectzLookupzzBaseId);
      if(!hasParent) return _Res.BadRequestzId("ProjectzLookupzzBaseId",data.ProjectzLookupzzBaseId);

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowInfra.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Update));
    }
  }
}