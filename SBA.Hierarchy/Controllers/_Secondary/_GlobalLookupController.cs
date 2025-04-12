using GLOB.Domain.Base;
using GLOB.Hierarchy.Global;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers;
[Route("[controller]")]
public class _GlobalLookupzController : Project_RDS_Controller<_GlobalLookupzController, GlobalLookupz>
{
  public _GlobalLookupzController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowProjectz.GlobalLookupzs;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<GlobalLookupzDtoSearch?> req)
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
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromQuery] DtoPageReq<GlobalLookupzDtoSearch?> req)
  {
    try
    {
      var data = await _repo.GetsPaginateOptions(req);
      return Ok(data);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(GetsPaginateOptions));
    }
  }
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] GlobalLookupzDtoCreate data)
  {
    if (!ModelState.IsValid) return Res_BadRequestModel();
    try
    {
      bool hasParent = _uowProjectz.GlobalLookupzBases.AnyId(data.GlobalLookupzBaseId);
      if(!hasParent) return Res_BadRequestzId("GlobalLookupzBaseId",data.GlobalLookupzBaseId);
      
      var result = _mapper.Map<GlobalLookupz>(data);
      var entity = await _repo.Insert(result);
      await _uowProjectz.Save();
      return Res_CreatedAtAction(nameof(Get), entity);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] GlobalLookupzDtoCreate data)
  {
    if (!ModelState.IsValid || Id < 1) return Res_NotFoundId(Id);
    try
    {
      var item = await _repo.Get(q => q.Id == Id);
      
      bool hasParent = _uowProjectz.GlobalLookupzBases.AnyId(data.GlobalLookupzBaseId);
      if(!hasParent) return Res_BadRequestzId("GlobalLookupzBaseId",data.GlobalLookupzBaseId);

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowProjectz.Save();
      return NoContent();
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}