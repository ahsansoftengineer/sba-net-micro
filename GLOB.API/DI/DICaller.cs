namespace GLOB.API.DI;
public static partial class DICommon
{
  public static void AddDICommon(this IServiceCollection srvc)
  {
    // Config_CachingService(srvc);
    // srvc.AddAuthentication();
    // srvc.AddAuthorization();
    srvc.Config_Cors();
    //srvc.AddAutoMapper(typeof(MapperInitializer)); // Later
    // Transient Means Fresh Copy
    srvc.Config_Controllerz();
    srvc.Config_Swagger();
    // srvc.Config_Versioning();
    // srvc.Config_FileHandling();
  }
  public static void AddDefaultExternalServices(this IServiceCollection srvc)
  {
    // srvc.Config_Identity();
    srvc.Config_Versioning();
    srvc.Config_HttpCacheHeaders();
    srvc.Config_RateLimiting();
    // srvc.Config_FileHandling();
  }
  public static void AddDefaultExternalConfiguration(this IApplicationBuilder app,
    IWebHostEnvironment env)
  {
    // app.Config_StaticFilesHandling();
    app.Config_DevEnv(env);
    app.Config_ExceptionHandler();
    app.UseHttpsRedirection();

    app.UseCors("CorsPolicyAllowAll");
    // app.Config_Caching();
    app.UseRouting();
    app.UseAuthentication();
    app.UseAuthorization();
    app.Config_EP();
  }
  
}