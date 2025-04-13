using GLOB.API.Configz;
using Microsoft.AspNetCore.Mvc;
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
      .AddControllers(options =>
      {
        options.Conventions.Insert(0, new GlobalRoutePrefixConvention(routePrefix));
      
        //options.Filters<Filters>();
        options.CacheProfiles.Add("120SecondsDuration", new CacheProfile
        {
          Duration = 5
          //,Location = ResponseCacheLocation.Client
          //,NoStore = true
          //,VaryByHeader = "I don't know which string"
          //,VaryByQueryKeys = "Any Keys"
        });
      })
      .ConfigureApiBehaviorOptions(options =>
      {
        options.InvalidModelStateResponseFactory = context =>
        {
          var errors =  context.ModelState.ToExtValidationError();
          return new BadRequestObjectResult(new
          {
              Errors = errors,
              Message = "Bad Request, Validation Failed"
          });
        };
      })
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
      c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
      {
        Title = ProjectNameSwagger,
        Version = "v1"
      });
      //c.IgnoreObsoleteProperties();
      //c.SchemaFilter<MySwaggerSchemaFilter>(); // Failed to apply this
    });
  }
  

}