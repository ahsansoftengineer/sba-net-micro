using GLOB.API.Config.DI;

namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{

  public static void Add_API_Default_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    // Add_Caching(srvc);
    // srvc.AddAuthentication();
    // srvc.AddAuthorization();
    srvc.Add_Cors_Gateway();
    srvc.Add_Swagger_Gateway(config);
    srvc.Add_Controller(config);
    // srvc.Add_Versioning();
  }
  public static void Add_API_Default_Srvc2(this IServiceCollection srvc)
  {
    // srvc.Config_Identity();
    // srvc.Add_Versioning();
    // srvc.Add_HttpCacheHeaders();
    // srvc.Config_RateLimiting();
    // srvc.Add_StaticFiles();
  }
}