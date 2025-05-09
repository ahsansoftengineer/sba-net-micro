using GLOB.API.Config.DI;

namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{

  public static void Add_API_Default_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    // Config_CachingService(srvc);
    // srvc.AddAuthentication();
    // srvc.AddAuthorization();
    srvc.Config_Cors_Gateway();
    srvc.Config_Swagger_Gateway(config);
    srvc.Config_Controllerz(config);
    // srvc.Config_Versioning();
  }
  public static void Add_API_Default_Srvc2(this IServiceCollection srvc)
  {
    // srvc.Config_Identity();
    // srvc.Config_Versioning();
    // srvc.Config_HttpCacheHeaders();
    // srvc.Config_RateLimiting();
    // srvc.Config_FileHandling();
  }
}