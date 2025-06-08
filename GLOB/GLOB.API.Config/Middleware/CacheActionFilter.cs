using System.Net;
using System.Reflection;
using GLOB.API.Config.Attributez;
using GLOB.API.Config.Ext;
using GLOB.API.Config.Srvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;

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
    ControllerActionDescriptor? descriptor;
    bool flowControl = AllowToContinue(context, out descriptor);
    if (!flowControl)
    {
      await next();
      return;
    }

    var routeValues = context.RouteData.Values; // controller, action, Id
    string action = (string)routeValues["action"];
    string Id = (string)routeValues["Id"];

    CacheModel cm = null;

    if (Id != null)
    {
      cm = new CacheModel
      {
        Controller = descriptor.ControllerName,
        Res = Id
      };
    }
    else if (action != "Create")
    {
      await next();
      return;
    }

    // Serve From Cache 
    var cached = await _cache.Get(cm);
    if (cached != null && action == "Get")
    {
      Console.WriteLine("Reading Data from Cache -->");
      context.Result = new ObjectResult(cached);
      return;
    }

    // Setting Cache By Read
    var executed = await next();

    if (executed.Result is ObjectResult result)
    {
      HttpStatusCode status = (HttpStatusCode)result?.StatusCode;

      if (status == HttpStatusCode.OK)
      {
        Console.WriteLine($"Handling Action {action} Status {status} in Cache -->");

        if (action == "Get")
        {
          cm.Value = result.Value;
          await _cache.Set(cm);
        }
        else if (action == "Update")
        {
          cm.Value = result.Value;
          await _cache.Set(cm);
        }
        else if (action == "Status")
        {
          cm.Value = result.Value;
          await _cache.Set(cm);
        }
      }
      else if (action == "Create" && status == HttpStatusCode.Created)
      {
        // ToExtVMSingle()
        dynamic obj = result.Value;
        cm.Res = obj?.Id;
        cm.Value = result.Value;
        await _cache.Set(cm);
      }
      else if (action == "Delete" && status == HttpStatusCode.NoContent)
      {
        await _cache.Remove(cm);
      }
    }
  }

  private static bool AllowToContinue(ActionExecutingContext context, out ControllerActionDescriptor? descriptor)
  {
    descriptor = context.ActionDescriptor as ControllerActionDescriptor;
    if (descriptor == null)
      return false;

    var method = descriptor.MethodInfo;
    var controllerType = context.Controller.GetType();

    bool hasNoCache = method?.GetCustomAttribute<NoCacheAttribute>() != null ||
                      controllerType.GetCustomAttribute<NoCacheAttribute>() != null;

    var cacheAttr = method?.GetCustomAttribute<CacheAttribute>() ??
                    controllerType.GetCustomAttribute<CacheAttribute>();

    if (hasNoCache || cacheAttr == null)
      return false;

    return true;
  }
}

public interface IEntityAlpha
{
  public string Id { get; set; }
  public string Name { get; set; }
}