
namespace GLOB.API.DI;
public static partial class DI_API
{
  private static void Use_API_DevEnv(this IApplicationBuilder app)
  {
    var env = app.GetSrvc<IWebHostEnvironment>();
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if (!env.IsProduction())
    {
      app.UseDeveloperExceptionPage();
      app.Use_API_Config_Swagger();
    } else {
      app.UseMiddleware<GlobalExceptionMiddleware>();
    }
  }
  public static void Add_API_Default_Middlewares(this IApplicationBuilder app)
  {
    app.Use_API_DevEnv();

    // app.UseHttpsRedirection();
    // app.Use_API_Config_Caching();

    app.UseRouting();

    //app.Use_API_Config_Localization();
    app.UseCors("PolicyAllowGateway");

    app.UseAuthentication();
    app.UseAuthorization();

    app.Use_API_Config_Controller();
  }


}