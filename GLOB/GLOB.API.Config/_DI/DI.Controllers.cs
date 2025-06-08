using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;

using GLOB.API.Config.Configz;
using GLOB.API.Config.Filterz;
using GLOB.API.Config.OptionSetup;
using GLOB.API.Config.Ext;

namespace GLOB.API.Config.DI;

public static partial class DI_API_Config
{

  public static void Use_Controller(this IApplicationBuilder app)
  {
    IConfiguration config = app.GetSrvc<IConfiguration>();
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX"); //"api/Hierarchy/v1";
    app.UseEndpoints(ep =>
    {
      ep.MapControllers();
    });
    app.Use(async (context, next) =>
    {
      string path = context.Request.Path;
      if (path == "/")
      {
        context.Response.Redirect($"/{prefix}/swagger/index.html");
        return;
      }
      await next();
    });
  }
  public static void Add_Controller(this IServiceCollection srvc, IConfiguration config)
  {
    srvc
      // API Caching 3. Defining Cache Profile
      .AddControllers(opt =>
      {
        opt.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseRouteTransformer()));
        opt.Conventions.Insert(0, new GlobalRoutePrefixConvention(config.GetValueStr("ASPNETCORE_ROUTE_PREFIX")));

        opt.CacheProfiles.Add("120SecondsDuration", new CacheProfile
        {
          Duration = 5
          //,Location = ResponseCacheLocation.Client
          //,NoStore = true
          //,VaryByHeader = "I don't know which string"
          //,VaryByQueryKeys = "Any Keys"
        });

        opt.Filters.Add<FilterCacheActionGet>();
        opt.Filters.Add<FilterCacheActionGets>();
        opt.Filters.Add<FilterCacheActionSave>();

        // NOTE: TODO: Uncomment For Auth
        // var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        // opt.Filters.Add(new AuthorizeFilter(policy));
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