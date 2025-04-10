using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Hierarchy.Controllers;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class _LookupController : API_2_RDS_Controller<_LookupController, ProjectzLookup>
{
  public _LookupController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookups;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<ProjectzLookupDtoSearch?> req)
  {
    try
    {
      var list = await _repo.GetsPaginate(req);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromQuery] DtoPageReq<ProjectzLookupDtoSearch?> req)
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
  public async Task<IActionResult> Create([FromBody] ProjectzLookupDtoCreate data)
  {
    if (!ModelState.IsValid) return BadRequestz();
    try
    {
      bool hasParent = _uowInfra.ProjectzLookupBases.AnyId(data.ProjectzLookupBaseId);
      if(!hasParent) return InvalidId("Invalid Lookup Base Id");

      var result = _mapper.Map<ProjectzLookup>(data);
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
  public async Task<IActionResult> Update(int id, [FromBody] ProjectzLookupDtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return InvalidId();
    try
    {
      var item = await _repo.Get(q => q.Id == id);
      if (item == null) return InvalidId();
      
      bool hasParent = _uowInfra.ProjectzLookupBases.AnyId(data.ProjectzLookupBaseId);
      if(!hasParent) return InvalidId("Invalid Lookup Base Id");

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