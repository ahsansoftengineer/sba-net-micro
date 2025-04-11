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
      var list = await _repo.GetsPaginate(req);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginateOptions([FromQuery] DtoPageReq<GlobalLookupzDtoSearch?> req)
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
  public async Task<IActionResult> Create([FromBody] GlobalLookupzDtoCreate data)
  {
    if (!ModelState.IsValid) return BadRequestz();
    try
    {
      bool hasParent = _uowProjectz.GlobalLookupzBases.AnyId(data.GlobalLookupzBaseId);
      if(!hasParent) return InvalidId("Invalid Global Lookupz Base Id");

      var result = _mapper.Map<GlobalLookupz>(data);
      await _repo.Insert(result);
      await _uowProjectz.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, [FromBody] GlobalLookupzDtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return InvalidId();
    try
    {
      var item = await _repo.Get(q => q.Id == id);
      if (item == null) return InvalidId();
      
      bool hasParent = _uowProjectz.GlobalLookupzBases.AnyId(data.GlobalLookupzBaseId);
      if(!hasParent) return InvalidId("Invalid Global Lookupz Base Id");

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uowProjectz.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}