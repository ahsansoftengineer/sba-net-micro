
using GLOB.API.DI;

namespace SBA.Hierarchy.DI;
public static partial class DIExternal
{
  public static IServiceCollection AddExternalServices(this IServiceCollection services)
  {
    services
      .ConfigureVersioning()
      .ConfigureIdentity()
      .ConfigureHttpCacheHeaders() // Enable on Production
      .ConfigureRateLimiting();
    services.ConfigureFileHandling();
    return services;
  }

    public static IApplicationBuilder AddExternalConfiguration(this IApplicationBuilder app,
    IWebHostEnvironment env)
  {
    // app.ConfigureStaticFilesHandling();
    app.ConfigureDevEnv(env);
    app.ConfigureExceptionHandler();
    app.UseHttpsRedirection();

    // app.UseCors("CorsPolicyAllowAll");

    // API Caching 2. Setting up Caching
    //app.UseResponseCaching(); // Enable Production
    // API Caching 7. Setting up Caching Profile at Globally
    //app.UseHttpCacheHeaders(); // Enable Production
    // API Throttling 4. Setting up Middleware
    // This is giving error while running
    //app.UseIpRateLimiting(); // Prevent Unnecessary Http Call from same User

    app.UseRouting();
    // app.UseAuthorization();
    app.UseEndpoints(ep =>
    {
      // This Routing is useful for MVC type application
      // Convention Based Routing Schema
      //ep.MapControllerRoute(
      //  name: "default",
      //  pattern: "{controller=Home}/{action=Index}/{id?}"); //
      ep.MapControllers();
    });

    return app;
  }
  
}