using System.Net;
using GLOB.Infra.Utils.Extz;
using GLOB.Infra.Data.Redisz;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GLOB.Infra.Utils.MIddlewarez;

public class FilterCacheActionGets : IAsyncActionFilter
{
  private readonly RedisCacheService _cache;

  public FilterCacheActionGets(IServiceProvider sp)
  {
    _cache = sp.GetSrvc<RedisCacheService>();
  }

  public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
  {
    ControllerActionDescriptor? descriptor;
    bool flowControl = FilterCacheActionSave.AllowToContinue(context, out descriptor, "Gets");
    if (!flowControl)
    {
      await next();
      return;
    }
    string controller = descriptor.ControllerName;

    var cached = await _cache.Get(new()
    {
      Controller = controller,
      Res = "All"
    });


    CacheModel cm = new() { Controller = controller };
    if (cached != null)
    {
      cm.Value = await _cache.Gets(cm);

      context.Result = new ObjectResult(cm.Value);
      return;
    }



    var executed = await next();

    if (executed.Result is ObjectResult result)
    {
      HttpStatusCode? status = (HttpStatusCode?)result?.StatusCode;
      if (status == HttpStatusCode.OK)
      {
        cm.Value = result.Value;
        await _cache.Sets(cm);
      }
    }
  }

}