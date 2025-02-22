using AutoMapper;
using GLOB.Domain.Base;
using GLOB.Domain.DTOs;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Controllers.Base;

namespace SBA.Hierarchy.Controllers;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class OUController : BasezController<OUController, OU, OUDto>
{
  public OUController(
    ILogger<OUController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.OUs;

  }
  [HttpGet("GetsPaginate")]
  public async Task<IActionResult> GetsPaginate([FromQuery] PaginateRequestFilter<OU, OUDtoSearch> req)
  {
    try
    {
      var list = await Repo.GetsPaginate(req);
      return Ok(list);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Gets));
    }
  }

  // [HttpPost]
  // public async Task<IActionResult> Create([FromBody] OUDtoCreate data)
  // {
  //   if (!ModelState.IsValid) return BadRequestz();
  //   try
  //   {
  //     bool hasParent = uOW.BGs.AnyId(data.LEId);
  //     if(!hasParent) return InvalidId("Invalid Business Group");

  //     var result = Mapper.Map<OU>(data);

  //     await Repo.Insert(result);
  //     await uOW.Save();

  //     return Ok(result);
  //   }
  //   catch (Exception ex)
  //   {
  //     return CatchException(ex, nameof(Create));
  //   }
  // }

  // [HttpPut("{id:int}")]
  // public async Task<IActionResult> Update(int id, [FromBody] OUDtoCreate data)
  // {
  //   if (!ModelState.IsValid || id < 1) return InvalidId();
  //   try
  //   {
  //     var item = await Repo.Get(q => q.Id == id);
  //     if (item == null) return InvalidId();
      
  //     bool hasParent = uOW.BGs.AnyId(data.LEId);
  //     if(!hasParent) return InvalidId("Invalid State");

  //     var result = Mapper.Map(data, item);

  //     Repo.Update(item);
  //     await uOW.Save();

  //     return Ok(result);
  //   }
  //   catch (Exception ex)
  //   {
  //     return CatchException(ex, nameof(Update));
  //   }
  // }
}