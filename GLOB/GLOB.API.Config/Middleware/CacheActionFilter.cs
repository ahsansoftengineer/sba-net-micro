using System.Reflection;
using GLOB.API.Config.Attributez;
using GLOB.API.Config.Srvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GLOB.API.Config.Filterz;
public class CacheActionFilter : IAsyncActionFilter
{
  private readonly RedisCacheService _cacheService;

  public CacheActionFilter(RedisCacheService cacheService)
  {
    _cacheService = cacheService;
  }

  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    var method = (context.ActionDescriptor as ControllerActionDescriptor)?.MethodInfo;
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

    var key = $"cache::{context.HttpContext.Request.Path}{context.HttpContext.Request.QueryString}";
    Console.WriteLine(key);
    var cached = await _cacheService.Get<object>(key);

    if (cached != null)
    {
      context.Result = new JsonResult(cached);
      return;
    }

    var executed = await next();

    if (executed.Result is ObjectResult result && result.StatusCode == 200)
    {
      await _cacheService.Set(key, result.Value, cacheAttr.DurationSeconds);
    }
  }
}
