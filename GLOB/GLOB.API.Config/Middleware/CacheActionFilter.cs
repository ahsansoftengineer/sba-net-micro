using System.Reflection;
using GLOB.API.Config.Attributez;
using GLOB.API.Config.Ext;
using GLOB.API.Config.Srvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GLOB.API.Config.Filterz;

public class CacheActionFilter : IAsyncActionFilter
{
  private readonly RedisCacheService _cache;

  public CacheActionFilter(IServiceProvider sp)
  {
    _cache = sp.GetSrvc<RedisCacheService>();
  }

  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
    if (descriptor == null)
    {
      await next();
      return;
    }

    var method = descriptor.MethodInfo;
    var controllerType = context.Controller.GetType();

    bool hasNoCache = method?.GetCustomAttribute<NoCacheAttribute>() != null ||
                      controllerType.GetCustomAttribute<NoCacheAttribute>() != null;

    var cacheAttr = method?.GetCustomAttribute<CacheAttribute>() ??
                    controllerType.GetCustomAttribute<CacheAttribute>();

    if (hasNoCache || cacheAttr == null)
    {
      await next();
      return;
    }

    var routeValues = context.RouteData.Values; // controller, action, Id
    CacheModel cm = null;

    if (routeValues.TryGetValue("Id", out object idObj) && idObj is string idStr)
    {
      cm = new CacheModel
      {
        Controller = descriptor.ControllerName,
        Res = idStr
      };
    }
    else
    {
      await next();
      return;
    }

    var cached = await _cache.Get(cm);
    if (cached != null)
    {
      Console.WriteLine("Reading Data from Cache -->");
      // ✅ Return the actual cached object directly
      context.Result = new ObjectResult(cached);
      return;
    }

    var executed = await next();

    if (executed.Result is ObjectResult result && result.StatusCode == 200)
    {
      cm.Value = result.Value;
      await _cache.Set(cm);
    }
  }
}
