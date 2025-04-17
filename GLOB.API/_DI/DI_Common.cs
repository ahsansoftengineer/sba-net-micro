using GLOB.API.Configz;
using GLOB.API.OptionSetup;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{

  public static void Config_DevEnv(this IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      Config_Swagger(app, env);
    }
  }
  public static void Config_Controller(this IApplicationBuilder app)
  {
    app.UseEndpoints(ep =>
    {
      // This Routing is useful for MVC type application
      // Convention Based Routing Schema
      //ep.MapControllerRoute(
      //  name: "default",
      //  pattern: "{controller=Home}/{action=Index}/{Id?}"); //
      ep.MapControllers();
    });
  }
  public static void Config_Controllerz(this IServiceCollection srvc, string routePrefix = "api/v1")
  {
    srvc
      // API Caching 3. Defining Cache Profile
      .AddControllers(opt =>
      {
        opt.Conventions.Add(new RouteTokenTransformerConvention(new KebabCaseRouteTransformer()));
        opt.Conventions.Insert(0, new GlobalRoutePrefixConvention(routePrefix));
      
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
          var errors =  context.ModelState.ToExtValidationError();
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



    public static void Config_Swagger(this IApplicationBuilder app, IWebHostEnvironment env)
  {

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trevor v1");
        c.DocExpansion(DocExpansion.None);
        //c.InjectJavascript("/js/swagger-custom.js"); //
      });
  }
  public static void Config_Swagger(this IServiceCollection srvc, string ProjectNameSwagger = "Swagger Name Project")
  {
    srvc.AddSwaggerGen(c =>
    {
      c.SchemaFilter<SwaggerNullablePrimitivesDataTypes>();
      // c.SchemaFilter<KebabCaseSchemaFilter>();
      c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
      {
        Title = ProjectNameSwagger,
        Version = "v1"
      });
      c.UseAllOfToExtendReferenceSchemas();
      c.SupportNonNullableReferenceTypes();
      c.IgnoreObsoleteProperties(); // [Obsolete]
    });
  }
  

}