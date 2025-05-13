using GLOB.API.Config.Configz;
using GLOB.API.Config.DI;
using GLOB.API.Config.Middleware;

namespace GLOB.API.DI;
public static partial class DI_API
{
  private static void Config_DevEnv(this IApplicationBuilder app)
  {
    var env = app.GetSrvc<IWebHostEnvironment>();
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.Config_Swagger();
    } else {
      app.UseMiddleware<GlobalExceptionMiddleware>();
    }
  }
  public static void Add_API_Default_Middlewares(this IApplicationBuilder app)
  {
    app.Config_DevEnv();

    // app.UseHttpsRedirection();
    // app.Config_Caching();

    app.UseRouting();

    //app.Config_Localization();
    app.UseCors("PolicyAllowGateway");

    app.UseAuthentication();
    app.UseAuthorization();

    app.Config_Controller();
  }


}