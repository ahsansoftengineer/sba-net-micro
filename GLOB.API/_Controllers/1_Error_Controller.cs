using AutoMapper;
using GLOB.Domain.Base;
using GLOB.Infra.UOW_Projectz;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.API.Controllers.Base;
public abstract class API_1_ErrorController<TController> : ControllerBase

{
  private readonly IServiceProvider _srvcProvider;
  protected readonly IMapper _mapper;
  protected readonly IUOW_Infra _uowInfra;
  protected readonly ILogger _logger;
  protected readonly IConfiguration _config;

  public API_1_ErrorController(IServiceProvider srvcProvider)
  {
    _srvcProvider = srvcProvider;
    _mapper = GetSrvc<IMapper>();
    _config = GetSrvc<IConfiguration>();
    _uowInfra = GetSrvc<IUOW_Infra>();

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
  protected ObjectResult Res_BadRequestz()
  {
    foreach (var ms in ModelState)
    {
      _logger.LogError($"{ms.Key} :\t {ms.Value}");
    }
    if (!ModelState.Any(x => x.Key == "Message"))
      ModelState.AddModelError("Message", "Bad Request 400");
    return BadRequest(ModelState);
  }
  protected ObjectResult Res_BadRequestz(IEnumerable<IdentityError> errors)
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
  protected ObjectResult Res_CreatedAtAction(string location, IEntityAlpha entity)
  {
    return CreatedAtAction(location, new { id = entity.Id }, entity);
  }
  protected ObjectResult Res_NotFoundUpdate(int Id)
  {
    return NotFound($"Invalid id {Id} not updated the record");
  }
  protected ObjectResult Res_NotFoundDelete(int Id)
  {
    return NotFound($"Invalid id {Id} not deleted the record");
  }
  protected ObjectResult Res_NotFoundStatus(int Id)
  {
    return NotFound($"Invalid id {Id} not updated the status");
  }
  protected ObjectResult Res_InvalidEnums(string status)
  {
    return NotFound($"Invalid data {status} not updated the record");
  }


  protected ObjectResult Res_NotAuthorised()
  {
    return BadRequest($"You don't permission to perform the action");
  }
}