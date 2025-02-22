using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract class AlphaController<TController> : ControllerBase
{
  protected ILogger<TController> Logger { get; }
  public AlphaController(ILogger<TController> logger)
  {
    Logger = logger;
  }

  protected ObjectResult CatchException(Exception ex, string methodName)
  {
    Logger.LogError(ex, $"Something went wrong in the {methodName}");
    return StatusCode(500, "Internal Server Error, Please try again later");
  }
    protected ObjectResult BadRequestz()
  {
    foreach(var ms in ModelState){
      Logger.LogError($"{ms.Key} :\t {ms.Value}");
    }
    if(!ModelState.Any(x => x.Key == "Message"))
      ModelState.AddModelError("Message", "Bad Request 400");
    return BadRequest(ModelState);
  }
  protected ObjectResult BadRequestz(string message = $"Bad Request fail to process")
  {
    ModelState.AddModelError("Message", message);
    return BadRequestz();
  }
  protected ObjectResult NotFound(string message = $"Invalid attempt record not found")
  {
    return BadRequestz(message);
  }
  protected ObjectResult NotAuthorised(string message = $"Invalid attempt you are not Authorised")
  {
    return BadRequestz(message);
  }
  protected ObjectResult InvalidId(string message = $"Invalid Id record not Updated")
  {
    return BadRequestz(message);
  }
  protected ObjectResult FileInvalid(string message = $"Invalid file not Uploaded")
  {
    return BadRequestz(message);
  }
  protected ObjectResult InvalidStatus(string message = $"Invalid Status record not updated")
  {
    ModelState.AddModelError("Status", "Invalid Status");
    return BadRequestz(message);
  }
  protected ObjectResult InvalidDelete(string message = $"Invalid Id record not Deleted")
  {
    return BadRequestz(message);
  }
}