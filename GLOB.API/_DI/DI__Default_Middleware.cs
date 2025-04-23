using GLOB.API.Middlewarez;
using GLOB.API.Configz;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  public static void Config_DevEnv(this IApplicationBuilder app)
  {
    var env = app.GetSrvc<IWebHostEnvironment>();
    Console.WriteLine($"Current Environment: {env.EnvironmentName}");
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      Config_Swagger(app);
    }
  }
  public static void Add_API_Default_Middlewares(this IApplicationBuilder app)
  {
    // app.UseMiddleware<GlobalExceptionMiddleware>();
    // app.Config_ExceptionHandler();
    app.Config_DevEnv();
    // app.UseHttpsRedirection();

    // app.UseCors("AllowGateway");
    // app.Config_Caching();
    app.UseRouting();
    // app.UseAuthentication();
    // app.UseAuthorization();
    app.Config_Controller();
  }

}