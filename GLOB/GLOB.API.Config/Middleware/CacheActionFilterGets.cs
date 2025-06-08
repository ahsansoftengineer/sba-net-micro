using GLOB.API.Config.Ext;
using GLOB.API.Config.Srvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GLOB.API.Config.Filterz;

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
    // await next();
    // return;
    var route = context.RouteData.Values; // controller, action, Id
    string action = (string)route["action"];

    CacheModel cm = new ()
    {
      Controller = descriptor.ControllerName,
    };

    // Serve From Cache 
    var cached = await _cache.Get(cm);
    if (cached != null)
    {
      Console.WriteLine("Reading Data from Cache -->");
      context.Result = new ObjectResult(cached);
      return;
    }
  }

}