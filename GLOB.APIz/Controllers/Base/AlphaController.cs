using AutoMapper;
using GLOB.Apps.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GLOB.API.Controllers.Base;
[Route("api/[controller]")]
[ApiController]
public abstract class AlphaController<TController> : ControllerBase
{
  protected ILogger<TController> Logger { get; }
  protected IMapper Mapper { get; }
  protected IUnitOfWorkz UnitOfWork { get; }
  public AlphaController(ILogger<TController> logger, IMapper mapper, IUnitOfWorkz unitOfWork)
  {
    Logger = logger;
    Mapper = mapper;
    UnitOfWork = unitOfWork;
  }

  protected ObjectResult CatchException(Exception ex, string methodName)
  {
    Logger.LogError(ex, $"Something went wrong in the {methodName}");
    return StatusCode(500, "Internal Server Error, Please try again later");
  }
  protected ObjectResult FileInvalid(string message = $"Invalid POST attempt in Create")
  {
    Logger.LogError(message);
    return BadRequest(ModelState);
  }
  protected ObjectResult CreateInvalid(string message = $"Invalid POST attempt in Create")
  {
    Logger.LogError(message);
    return BadRequest(ModelState);
  }
  protected ObjectResult UpdateInvalid(string message = $"Invalid UPDATE attempt in Update")
  {
    Logger.LogError(message);
    return BadRequest(ModelState);
  }
  protected ObjectResult StatusInvalid(string message = $"Invalid STATUS attempt in Update")
  {
    Logger.LogError(message);
    return BadRequest(ModelState);
  }
  protected ObjectResult UpdateNull(string message = $"Invalid UPDATE attempt in Update")
  {
    Logger.LogError(message);
    return BadRequest("Submit Data is Invalid");
  }

  protected ObjectResult DeleteInvalid(string message = $"Invalid DELETE attempt in Delete")
  {
    Logger.LogError(message);
    return BadRequest("Submit id is Negative");
  }
  protected ObjectResult DeleteNull(string message = $"Invalid DELETE attempt in Delete")
  {
    Logger.LogError(message);
    return BadRequest("Submit id is Invalid");

  }
}