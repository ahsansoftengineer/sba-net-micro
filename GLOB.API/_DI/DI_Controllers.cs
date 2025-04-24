using GLOB.API.Configz;
using GLOB.API.OptionSetup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
 
  public static void Config_Controller(this IApplicationBuilder app)
  {
    IConfiguration config = app.GetSrvc<IConfiguration>();
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX"); //"api/Hierarchy/v1";
    app.UseEndpoints(ep =>
    {
      ep.MapControllers();
    });
    app.Use(async (context, next) =>
    {
      if (context.Request.Path == "/" || context.Request.Path == "/swagger/index.html" )
      {
        context.Response.Redirect($"/{prefix}/swagger/index.html");
        return;
      }
      await next();
    });
  }
  public static void Config_Controllerz(this IServiceCollection srvc, IConfiguration config)
  {
    srvc
      // API Caching 3. Defining Cache Profile
      .AddControllers(opt =>
      {
        // opt.Conventions.Add(new GlobalRouteConvention());
        opt.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseRouteTransformer()));
        opt.Conventions.Insert(0, new GlobalRoutePrefixConvention(config.GetValueStr("ASPNETCORE_ROUTE_PREFIX")));
        //opt.Filters<Filters>();
        opt.CacheProfiles.Add("120SecondsDuration", new CacheProfile
        {
          Duration = 5
          //,Location = ResponseCacheLocation.Client
          //,NoStore = true
          //,VaryByHeader = "I don't know which string"
          //,VaryByQueryKeys = "Any Keys"
        });
      })
      .ConfigureApiBehaviorOptions(opt =>
      {
        opt.InvalidModelStateResponseFactory = context =>
        {
          var errors = context.ModelState.ToExtValidationError();
          return new BadRequestObjectResult(new
          {
            Errors = errors,
            Message = "Bad Request, Validation Failed"
          });
        };
      })
      // Config for Model Prop to KebabCase
      // .AddJsonOptions(opt =>
      // {
      //   opt.JsonSerializerOptions.PropertyNamingPolicy = new KebabCaseNamingPolicy();
      // })
      .AddNewtonsoftJson(opt =>
      {
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
      });

  }

}