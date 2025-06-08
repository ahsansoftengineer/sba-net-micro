using GLOB.API.Config.Ext;
using GLOB.API.Config.Srvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GLOB.API.Config.Filterz;

public class FilterCacheActionGet : IAsyncActionFilter
{
  private readonly RedisCacheService _cache;

  public FilterCacheActionGet(IServiceProvider sp)
  {
    _cache = sp.GetSrvc<RedisCacheService>();
  }

  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    ControllerActionDescriptor? descriptor;
    bool flowControl = FilterCacheActionSave.AllowToContinue(context, out descriptor, "Get");
    if (!flowControl)
    {
      await next();
      return;
    }

    var route = context.RouteData.Values; // controller, action, Id
    string Id = (string)route["Id"];

    CacheModel cm = new ()
    {
      Controller = descriptor.ControllerName,
    };

    if (Id != null)
      cm.Res = Id;

    var cached = await _cache.Get(cm);
    if (cached != null)
    {
      Console.WriteLine("Reading Data from Cache -->");
      context.Result = new ObjectResult(cached);
      return;
    }
  }

}