using GLOB.API.Config.Configz;
using GLOB.API.Config.DI;
using GLOB.API.Config.Middleware;

namespace GLOB.API.DI;
public static partial class DI_API
{
  private static void Use_DevEnv(this IApplicationBuilder app)
  {
    var env = app.GetSrvc<IWebHostEnvironment>();
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if (!env.IsProduction())
    {
      app.UseDeveloperExceptionPage();
      app.Use_Swagger();
    } else {
      app.UseMiddleware<GlobalExceptionMiddleware>();
    }
  }
  public static void Add_API_Default_Middlewares(this IApplicationBuilder app)
  {
    app.Use_DevEnv();

    // app.UseHttpsRedirection();
    // app.Config_Caching();

    app.UseRouting();

    //app.Use_Localization();
    app.UseCors("PolicyAllowGateway");

    app.UseAuthentication();
    app.UseAuthorization();

    app.Use_Controller();
  }


}