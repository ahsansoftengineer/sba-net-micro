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
  // private readonly string Prefix;

  public CacheActionFilter(IServiceProvider sp)
  {
    _cache = sp.GetSrvc<RedisCacheService>();
    // Prefix = sp.GetSrvc<IOptions<AppSettings>>()?.Value?.ASPNETCORE_ROUTE_PREFIX ?? "No/Prefix";
  }

  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    var descriptor = context.ActionDescriptor as ControllerActionDescriptor;
    if (descriptor != null)
    {
      var method = descriptor?.MethodInfo;
      var controller = context.Controller.GetType();

      bool hasNoCache = method?.GetCustomAttribute<NoCacheAttribute>() != null ||
                controller.GetCustomAttribute<NoCacheAttribute>() != null;

      if (hasNoCache)
      {
        await next();
        return;
      }

      var cacheAttr = method?.GetCustomAttribute<CacheAttribute>() ??
        controller.GetCustomAttribute<CacheAttribute>();

      if (cacheAttr == null)
      {
        await next();
        return;
      }

      var routeValues = context.RouteData.Values;

      CacheModel cm = null;
      if (routeValues.TryGetValue("Id", out object Id))
      {
        cm = new()
        {
          Controller = descriptor.ControllerName,
          // EP = descriptor.ActionName,
          Res = (string)Id ?? ""
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
        Console.WriteLine("Reading Data from Cache --> ");
        context.Result = new JsonResult(cached);
        return;
      }

      var executed = await next();

      if (executed.Result is ObjectResult result && result.StatusCode == 200)
      {
        cm.Value = ((ObjectResult)executed.Result).Value;

        await _cache.Set(cm);
      }
    }
    else
    {
      await next();
    }

  }
}
