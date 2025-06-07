using AutoMapper;
using GLOB.API.Config.Configz;
using GLOB.API.Config.Ext;
using GLOB.API.Config.Srvc;
using GLOB.Infra.UOW_Projectz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace GLOB.API.Controllers.Base;

[Route("[controller]/[action]")]
[ApiController] //[NoCache]
public abstract class API_1_ErrorController<TController> : ControllerBase

{
  protected readonly IServiceProvider _sp;
  protected readonly IMapper _mapper;
  protected readonly IUOW_Infra _uowInfra;
  protected readonly ILogger _logger;
  protected readonly IConfiguration _config;
  protected readonly AppSettings _appSettings;

  protected readonly RedisCacheService _redis;

  public API_1_ErrorController(IServiceProvider sp)
  {
    _sp = sp;
    _config = sp.GetSrvc<IConfiguration>();
    _appSettings = sp.GetSrvc<IOptions<AppSettings>>().Value;

    _mapper = sp.GetSrvc<IMapper>();
    _uowInfra = sp.GetSrvc<IUOW_Infra>();
    _redis = sp.GetSrvc<RedisCacheService>();

    _logger = sp.GetSrvc<ILogger<TController>>();

    

    Console.WriteLine("--> Port: {0}, Prefix: {1}", _appSettings.ASPNETCORE_HTTPS_PORT, _appSettings.ASPNETCORE_ROUTE_PREFIX);
    Console.WriteLine("--> Action : {0}", this);
  }

}