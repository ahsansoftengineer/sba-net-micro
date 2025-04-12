using GLOB.API.Controllers.Base;
using GLOB.API.Staticz;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Projectz.Controllers;
[Route("[controller]")]
[ApiController]
public class _LookupzController : API_2_RDS_Controller<_LookupzController, ProjectzLookupz>
{
  public _LookupzController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookupzs;
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] ProjectzLookupzDtoCreate data)
  {
    if (!ModelState.IsValid) return _Res.BadRequestModel(ModelState);
    try
    {
      bool hasParent = _uowInfra.ProjectzLookupzBases.AnyId(data.ProjectzLookupzBaseId);
      if(!hasParent) return _Res.BadRequestzId("ProjectzLookupzBaseId",data.ProjectzLookupzBaseId);

      var result = _mapper.Map<ProjectzLookupz>(data);
      await _repo.Insert(result);
      await _uowInfra.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] ProjectzLookupzDtoCreate data)
  {
    try
    {
      if (!ModelState.IsValid) return _Res.BadRequestModel(ModelState);
      if(Id < 1) return _Res.NotFoundId(Id);

      var item = await _repo.Get(q => q.Id == Id);
      if (item == null) return _Res.NotFoundId(Id);
      
      bool hasParent = _uowInfra.ProjectzLookupzBases.AnyId(data.ProjectzLookupzBaseId);
      if(!hasParent) return _Res.BadRequestzId("ProjectzLookupzBaseId",data.ProjectzLookupzBaseId);

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