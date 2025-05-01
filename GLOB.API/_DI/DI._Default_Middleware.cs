using GLOB.API.Config.DI;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
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