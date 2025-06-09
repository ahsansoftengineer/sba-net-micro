using GLOB.API.Config.DI;
using GLOB.API.Config.Extz;

namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{
  private static void Use_DevEnv(this IApplicationBuilder app)
  {
    var env = app.GetSrvc<IWebHostEnvironment>();
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if (!env.IsProduction())
    {
      app.UseDeveloperExceptionPage();
      app.Use_Swagger_Gateway();
    }
  }
  public static void Add_API_Default_Middlewares(this IApplicationBuilder app)
  {
    // app.UseMiddleware<GlobalExceptionMiddleware>();
    // app.Use_ExceptionHandler();
    app.Use_DevEnv();
    // app.UseHttpsRedirection();
    // app.Config_Caching();
    app.UseRouting();
    // app.UseCors("AllowGateway");
    // app.UseAuthentication();
    // app.UseAuthorization();
    app.Use_Controller();


  }

}