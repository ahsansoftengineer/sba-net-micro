using GLOB.API.Staticz;
using GLOB.Domain.Base;
using GLOB.Hierarchy.Global;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers;
[Route("[controller]")]
public class _GlobalLookupzzController : Project_RDS_Controller<_GlobalLookupzzController, GlobalLookupzz>
{
  public _GlobalLookupzzController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowProjectz.GlobalLookupzzs;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] DtoPageReq<GlobalLookupzzDtoSearch?> req)
  {
    return await _Actionz.GetsPaginatez(_repo, req);
  }
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromQuery] DtoPageReq<GlobalLookupzzDtoSearch?> req)
  {
    return await _Actionz.GetsPaginateOptionsz(_repo, req);
  }
  [HttpPost]
  public async Task<IActionResult> Create([FromBody] GlobalLookupzzDtoCreate data)
  {
    try
    {
      bool hasParent = _uowProjectz.GlobalLookupzzBases.AnyId(data.GlobalLookupzzBaseId);
      if(!hasParent) return _Res.BadRequestzId("GlobalLookupzzBaseId",data.GlobalLookupzzBaseId);
      
      var result = _mapper.Map<GlobalLookupzz>(data);
      var entity = await _repo.Insert(result);
      await _uowProjectz.Save();
      return _Res.CreatedAtAction(this, nameof(Get), entity);
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{Id:int}")]
  public async Task<IActionResult> Update(int Id, [FromBody] GlobalLookupzzDtoCreate data)
  {
    try
    {
      var item = await _repo.Get(q => q.Id == Id);
      
      bool hasParent = _uowProjectz.GlobalLookupzzBases.AnyId(data.GlobalLookupzzBaseId);
      if(!hasParent) return _Res.BadRequestzId("GlobalLookupzzBaseId",data.GlobalLookupzzBaseId);

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowProjectz.Save();
      return NoContent();
    }
    catch (Exception ex)
    {
      return _Res.CatchException(ex, nameof(Update));
    }
  }
}