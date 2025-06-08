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

    CacheModel cm = new ()
    {
      Controller = descriptor.ControllerName,
    };

    if (Id != null)
      cm.Res = Id;

    // Serve From Cache 
    if (action == "Get")
    {
      var cached = await _cache.Get(cm);
      if (cached != null)
      {
        Console.WriteLine("Reading Data from Cache -->");
        context.Result = new ObjectResult(cached);
        return;
      }
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
        else if (action == "Delete")
        {
          await _cache.Remove(cm);
        }
      }
      else if (action == "Create" && status == HttpStatusCode.Created)
      {
        var prop = result.Value?.GetType().GetProperty("Id");
        var idValue = prop?.GetValue(result.Value, null);
        if (idValue != null)
          cm.Res = idValue.ToString();

        cm.Value = new
        {
          Record = result.Value,
          Status = HttpStatusCode.OK
        };
        await _cache.Set(cm);
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

    var action = (string)context.RouteData.Values["action"]; // controller, action, Id

    if (action == null || "Create, Update, Delete, Status, Get".IndexOf(action) == -1)
      return false;

    return true;
  }
}