using AutoMapper;
using GLOB.Infra.UOW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract class API_1_ErrorController<TController> : ControllerBase

{
  private readonly IServiceProvider _srvcProvider;
  protected readonly IMapper _mapper;
  protected readonly IUnitOfWorkInfra _uowInfra;
  protected readonly ILogger _logger;
  protected readonly IConfiguration _config;

  public API_1_ErrorController(IServiceProvider srvcProvider)
  {
    _srvcProvider = srvcProvider;
    _mapper = GetSrvc<IMapper>();
    _config = GetSrvc<IConfiguration>();
    _uowInfra = GetSrvc<IUnitOfWorkInfra>();

    _logger = GetSrvc<ILogger<TController>>();
    _logger.LogWarning("How does Type Works -> "+ this);
  }
  protected TService GetSrvc<TService>()
  where TService: class
  {
    try
    {
      return _srvcProvider.GetRequiredService<TService>();

    } 
    catch(Exception ex) 
    {
      Console.WriteLine($"------------------------****-*-****------------------------");
      Console.WriteLine($"Please Regiseter Service in DI {nameof(TService)}");
      Console.WriteLine(ex.Message);
      return null;
    }
  }


  protected ObjectResult CatchException(Exception ex, string methodName)
  {
    _logger.LogError(ex, $"Something went wrong in the {methodName}");
    return StatusCode(500, "Internal Server Error, Please try again later");
  }

  protected ObjectResult BadRequestz(IEnumerable<IdentityError> errors)
  {
    foreach (var item in errors)
    {
      ModelState.AddModelError(item.Code, item.Description);
    }
    foreach (var ms in ModelState)
    {
      _logger.LogError($"{ms.Key} :\t {ms.Value}");
    }
    if (!ModelState.Any(x => x.Key == "Message"))
      ModelState.AddModelError("Message", "Bad Request 400");
    return BadRequest(ModelState);
  }
  protected ObjectResult BadRequestz()
  {
    foreach (var ms in ModelState)
    {
      _logger.LogError($"{ms.Key} :\t {ms.Value}");
    }
    if (!ModelState.Any(x => x.Key == "Message"))
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