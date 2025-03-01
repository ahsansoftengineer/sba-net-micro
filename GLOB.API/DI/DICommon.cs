using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GLOB.API.DI;
public static partial class DICommon
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
      //  pattern: "{controller=Home}/{action=Index}/{id?}"); //
      ep.MapControllers();
    });
  }
  public static void Config_Controllerz(this IServiceCollection srvc)
  {
    srvc
      // API Caching 3. Defining Cache Profile
      .AddControllers(config =>
      {
        //config.Filters<Filters>();
        config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
        {
          Duration = 5
          //,Location = ResponseCacheLocation.Client
          //,NoStore = true
          //,VaryByHeader = "I don't know which string"
          //,VaryByQueryKeys = "Any Keys"
        });
      })
      .AddNewtonsoftJson(opt =>
      {
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
        opt.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
      });

  }
  public static void Config_Swagger(this IServiceCollection srvc, string title = "Micro")
  {
    srvc.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
      {
        Title = title,
        Version = "v1"
      });
      //c.IgnoreObsoleteProperties();
      //c.SchemaFilter<MySwaggerSchemaFilter>(); // Failed to apply this
    });
  }
  

}