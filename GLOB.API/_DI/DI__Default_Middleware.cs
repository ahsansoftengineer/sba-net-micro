using GLOB.API.Middlewarez;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  public static T GetSrvc<T>(this IApplicationBuilder app)
  where T : notnull
  {
    return app.ApplicationServices.GetRequiredService<T>();
  }

  public static void Config_DevEnv(this IApplicationBuilder app)
  {
    var env = app.GetSrvc<IWebHostEnvironment>();
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      Config_Swagger(app);
    }
  }
  public static void AddDefaultExternalConfiguration(this IApplicationBuilder app)
  {
    // app.Config_StaticFilesHandling();
    app.UseMiddleware<GlobalExceptionMiddleware>();
    app.Config_DevEnv();
    app.Config_ExceptionHandler();
    app.UseHttpsRedirection();

    // app.UseCors("AllowGateway");
    // app.Config_Caching();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.Config_Controller();
  }

}