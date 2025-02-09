using AutoMapper;
using GLOB.Apps.Common;
using GLOB.Domain.Base;
using GLOB.Domain.Common;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
[Route("api/[controller]")]
[ApiController]
public abstract class CommonStatusController<TController, TEntity> 
  : BetaController<
    TController,
    TEntity,
    CommonStatusDtoSearch,
    CommonStatusDto,
    CommonStatusDtoCreate>
  where TController : class
  where TEntity : BaseStatusEntity
{
  public CommonStatusController(
    ILogger<TController> logger,
    IMapper mapper,
    IUnitOfWorkz unitOfWork) : base(logger, mapper, unitOfWork) { }

  [HttpPut("status/{id:int}")]
  public async Task<IActionResult> Status(int id, [FromBody] Status status)
  {
    if (!ModelState.IsValid || id < 1) return StatusInvalid();
    try
    {
      var item = await Repo.Get(q => q.Id == id);

      if (item == null) return UpdateNull();

      item.Status = status;
      Repo.Update(item);
      await UnitOfWork.Save();
      return Ok(item);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}