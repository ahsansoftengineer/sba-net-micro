using GLOB.Domain.Base;
using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Test;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class LEController : BasezController<LEController, LE, LEDtoRead>
{
  public LEController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.LEs;
  }

  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<LEDtoSearch> req)
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

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] LEDtoCreate data)
  {
    if (!ModelState.IsValid) return BadRequestz();
    try
    {
      bool hasParent = _uow.BGs.AnyId(data.BGId);
      if(!hasParent) return InvalidId("Invalid Business Group");

      var result = _mapper.Map<LE>(data);

      await _repo.Insert(result);
      await _uow.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, [FromBody] LEDtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return InvalidId();
    try
    {
      var item = await _repo.Get(q => q.Id == id);
      if (item == null) return InvalidId();
      
      bool hasParent = _uow.BGs.AnyId(data.BGId);
      if(!hasParent) return InvalidId("Invalid State");

      var result = _mapper.Map(data, item);
      _repo.Update(item);
      await _uow.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}