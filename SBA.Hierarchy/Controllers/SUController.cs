using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using GLOB.Domain.DTOs;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using SBA.Hierarchy.App;

namespace SBA.Hierarchy.Controllers;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class SUController : BaseController<SUController, SU, SUDto>
{
  public SUController(
    ILogger<SUController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.SUs;

  }

  // [HttpGet]
  // public async Task<IActionResult> Gets([FromQuery] PaginateRequestFilter<SU, SUDtoSearch?> filter)
  // {
  //   try
  //   {
  //     var list = await Repo.GetsPaginate(filter);
  //     return Ok(list);
  //   }
  //   catch (Exception ex)
  //   {
  //     return CatchException(ex, nameof(Gets));
  //   }
  // }

  // [HttpGet("{id:int}")]
  // public async Task<IActionResult> Get(int id)
  // {
  //   var single = await Repo.Get(
  //     q => q.Id == id
  //    //, new List<string> { "Org" }
  //    );
  //   var result = Mapper.Map<BaseDtoSingle<SUDto>>(single);
  //   return Ok(result);
  // }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] SUDtoCreate data)
  {
    if (!ModelState.IsValid) return CreateInvalid();
    try
    {
      var result = Mapper.Map<SU>(data);
      await Repo.Insert(result);
      await UnitOfWork.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Create));
    }
  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, [FromBody] SUDtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return UpdateInvalid();
    try
    {
      var item = await Repo.Get(q => q.Id == id);

      if (item == null) return UpdateNull();
      var result = Mapper.Map(data, item);
      Repo.Update(item);
      await UnitOfWork.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}