using AutoMapper;
using GLOB.API.Config.Configz;
using GLOB.API.Staticz;
using GLOB.Infra.UOW_Projectz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GLOB.API.Controllers.Base;

[Route("[controller]/[action]")]
[ApiController]
public abstract class API_1_ErrorController<TController> : ControllerBase

{
  private readonly IServiceProvider _srvcProvider;
  protected readonly IMapper _mapper;
  protected readonly IUOW_Infra _uowInfra;
  protected readonly ILogger _logger;
  protected readonly IConfiguration _config;
  protected readonly AppSettings _appSettings;

  public API_1_ErrorController(IServiceProvider srvcProvider)
  {
    _srvcProvider = srvcProvider;
    _config = GetSrvc<IConfiguration>();
    _appSettings = GetSrvc<IOptions<AppSettings>>().Value;

    _mapper = GetSrvc<IMapper>();
    _uowInfra = GetSrvc<IUOW_Infra>();
    _logger = GetSrvc<ILogger<TController>>();

    Console.WriteLine("--> Port: {0}, Prefix: {1}", _appSettings.ASPNETCORE_HTTPS_PORT, _appSettings.ASPNETCORE_ROUTE_PREFIX);
    Console.WriteLine("--> Action : {0}", this);
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
}