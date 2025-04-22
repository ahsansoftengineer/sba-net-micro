using GLOB.API.Mapper;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{

  public static void Add_API_DI_Common(this IServiceCollection srvc, IConfiguration config)
  {
    // Config_CachingService(srvc);
    // srvc.AddAuthentication();
    // srvc.AddAuthorization();
    srvc.Config_Cors();
    srvc.AddAutoMapper(typeof(API_Base_Mapper));
    srvc.Config_Controllerz(config); // Commented because of MVC Customization
    srvc.Config_Swagger(config);
    // srvc.Config_Versioning();
  }
  public static void Add_API_DefaultExternalServices(this IServiceCollection srvc)
  {
    // srvc.Config_Identity();
    srvc.Config_Versioning();
    srvc.Config_HttpCacheHeaders();
    srvc.Config_RateLimiting();
    // srvc.Config_FileHandling();
  }
}