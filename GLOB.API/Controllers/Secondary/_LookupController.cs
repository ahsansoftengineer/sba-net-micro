using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Identity;
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

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<ProjectzLookupzDtoSearch?> req)
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
  public async Task<IActionResult> GetsPaginateOptions([FromQuery] DtoPageReq<ProjectzLookupzDtoSearch?> req)
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
  public async Task<IActionResult> Create([FromBody] ProjectzLookupzDtoCreate data)
  {
    if (!ModelState.IsValid) return Res_BadRequestModel();
    try
    {
      bool hasParent = _uowInfra.ProjectzLookupzBases.AnyId(data.ProjectzLookupzBaseId);
      
      if(!hasParent) {
        return Res_BadRequestModel(new IdentityError(){
          Code = "ProjectzLookupzBaseId", 
          Description = $"Invalid ProjectzLookupzBase {data.ProjectzLookupzBaseId} record not created"
        });
      }

      var result = _mapper.Map<ProjectzLookupz>(data);
      await _repo.Insert(result);
      await _uowInfra.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] ProjectzLookupzDtoCreate data)
  {
    try
    {
      if (!ModelState.IsValid) return Res_BadRequestModel();
      if(Id < 1) return Res_NotFoundId(Id);

      var item = await _repo.Get(q => q.Id == Id);
      if (item == null) return Res_NotFoundId(Id);
      
      bool hasParent = _uowInfra.ProjectzLookupzBases.AnyId(data.ProjectzLookupzBaseId);
      if(!hasParent) {
        return Res_BadRequestModel(new IdentityError(){
          Code = "ProjectzLookupzBaseId", 
          Description = $"Invalid ProjectzLookupzBase {data.ProjectzLookupzBaseId} record not created"
        });
      }

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