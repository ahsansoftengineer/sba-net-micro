
using GLOB.API.Config.Configz;
using GLOB.API.Config.DI;

namespace GLOB.API.DI;
public static partial class API_Config_DI_Common
{
  public static void Config_DevEnv(this IApplicationBuilder app)
  {
    var env = app.GetSrvc<IWebHostEnvironment>();
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.Config_Swagger();
    }
  }
  public static void Add_API_Default_Middlewares(this IApplicationBuilder app)
  {
    // app.UseMiddleware<GlobalExceptionMiddleware>();
    // app.Config_ExceptionHandler();
    app.Config_DevEnv();
    // app.UseHttpsRedirection();

    // app.Config_Caching();
    app.UseRouting();
    app.UseCors("PolicyAllowGateway");
    // app.UseAuthentication();
    // app.UseAuthorization();
    app.Config_Controller();
  }

}