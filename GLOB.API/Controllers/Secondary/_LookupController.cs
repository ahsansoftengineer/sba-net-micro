using GLOB.API.Controllers.Base;
using GLOB.API.Staticz;
using GLOB.Domain.Base;
using GLOB.Infra.Paginate;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Projectz.Controllers;
public class _ProjectzLookupzController : API_2_RDS_Controller<_ProjectzLookupzController, ProjectzLookup>
{
  public _ProjectzLookupzController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookups;
  }

  [HttpPost]
  public async Task<IActionResult> GetsPaginate([FromBody] DtoRequestPage<ProjectzLookupDtoSearch?> req)
  {
    return await _repo.ToActionGetsPaginate(req);
  }

  [HttpPost]
  public async Task<IActionResult> GetsPaginateOptions([FromBody] DtoRequestPage<ProjectzLookupDtoSearch?> req)
  {
    return await _repo.ToActionGetsPaginateOptions(req);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] ProjectzLookupDtoCreate data)
  {
    try
    {
      bool hasParent = _uowInfra.ProjectzLookupBases.AnyId(data.ProjectzLookupBaseId);
      if (!hasParent) return _Res.BadRequestzId("ProjectzLookupBaseId", data.ProjectzLookupBaseId);

      var result = _mapper.Map<ProjectzLookup>(data);
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
  public async Task<IActionResult> Update(int Id, [FromBody] ProjectzLookupDtoCreate data)
  {
    try
    {
      if (Id < 1) return _Res.NotFoundId(Id);

      var item = await _repo.Get(q => q.Id == Id);
      if (item == null) return _Res.NotFoundId(Id);

      bool hasParent = _uowInfra.ProjectzLookupBases.AnyId(data.ProjectzLookupBaseId);
      if (!hasParent) return _Res.BadRequestzId("ProjectzLookupBaseId", data.ProjectzLookupBaseId);

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowInfra.Save();
      return result.ToExtVMSingle().Ok();
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Update));
    }
  }
}