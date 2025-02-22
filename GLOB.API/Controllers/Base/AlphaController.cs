using AutoMapper;
using GLOB.Apps.Common;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract class AlphaController<TController> : ControllerBase
{
  protected ILogger<TController> Logger { get; }
  protected IMapper Mapper { get; }
  public AlphaController(ILogger<TController> logger, IMapper mapper)
  {
    Logger = logger;
    Mapper = mapper;
  }

  protected ObjectResult CatchException(Exception ex, string methodName)
  {
    Logger.LogError(ex, $"Something went wrong in the {methodName}");
    return StatusCode(500, "Internal Server Error, Please try again later");
  }
  protected ObjectResult BadRequestz(string message = $"Bad Request fail to Process")
  {
    Logger.LogError(message);

    return BadRequest(ModelState);
  }
  protected ObjectResult NotFound(string message = $"No Record Found")
  {
    return BadRequestz(message);
  }
  protected ObjectResult NotAuthorised(string message = $"You are not allow to make this request")
  {
    return BadRequestz(message);
  }
  protected ObjectResult InvalidId(string message = $"Invalid Id Record not Updated")
  {
    return BadRequestz(message);
  }
  protected ObjectResult FileInvalid(string message = $"Invalid File Extension")
  {
    return BadRequestz(message);
  }
  protected ObjectResult InvalidStatus(string message = $"Status not Updated")
  {
    return BadRequestz(message);
  }
  protected ObjectResult InvalidDelete(string message = $"Record not Deleted")
  {
    return BadRequestz(message);
  }
}