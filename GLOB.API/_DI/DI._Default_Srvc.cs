using GLOB.API.Mapper;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{

  public static void Add_API_Default_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    // Config_CachingService(srvc);
    // srvc.AddAuthentication();
    // srvc.AddAuthorization();
    srvc.Config_Cors();
    srvc.AddAutoMapper(typeof(API_Base_Mapper));
    srvc.Config_Swagger(config);
    srvc.Config_Controllerz(config);
    // srvc.Config_Versioning();
  }
  public static void Add_API_Default_Srvc2(this IServiceCollection srvc)
  {
    // srvc.Config_Identity();
    srvc.Config_Versioning();
    srvc.Config_HttpCacheHeaders();
    srvc.Config_RateLimiting();
    // srvc.Config_FileHandling();
  }
}