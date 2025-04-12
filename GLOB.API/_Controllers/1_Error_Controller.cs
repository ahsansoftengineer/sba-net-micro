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

  // Bad Request
  protected ObjectResult Res_BadRequestModel()
  {
    foreach (var ms in ModelState)
    {
      _logger.LogError($"{ms.Key} :\t {ms.Value}");
    }
    if (!ModelState.Any(x => x.Key == "Message"))
      ModelState.AddModelError("Message", "Bad Request 400");
    return BadRequest(ModelState);
  }
  protected ObjectResult Res_BadRequestModel(IdentityError error)
  {
    ModelState.AddModelError(error.Code, error.Description);
    return Res_BadRequestModel();
  }
  protected ObjectResult Res_BadRequestzId(string Code, int Id)
  {
    return Res_BadRequestzId(Code, Id.ToString());
  }
  protected ObjectResult Res_BadRequestzId(string Code, string Id)
  {
    return Res_BadRequestModel(new (){
      Code = Code, 
      Description = $"Invalid {Code} {Id}"
    });
  }

  // CreatedAt
  protected ObjectResult Res_CreatedAtAction(string location, IEntityAlpha entity)
  {
    return CreatedAtAction(location, new { Id = entity.Id }, entity);
  }

  // Not Found Ids
  protected ObjectResult Res_NotFoundId(string Id)
  {
    return Res_NotFoundId("Id", Id.ToString());
  }
  protected ObjectResult Res_NotFoundId(int Id)
  {
    return Res_NotFoundId("Id", Id.ToString());
  }
  protected ObjectResult Res_NotFoundId(string Key, int Id)
  {
    return Res_NotFoundId(Key, Id.ToString());
  }
  protected ObjectResult Res_NotFoundId(string Key, string Id)
  {
    return NotFound($"Invalid {Key} {Id}");
  }

  // Invalid Enums
  protected ObjectResult Res_InvalidEnums(string status)
  {
    return NotFound($"Invalid data {status} not updated the record");
  }

  // Not Authorized
  protected ObjectResult Res_NotAuthorised()
  {
    return BadRequest($"You don't permission to perform the action");
  }
}