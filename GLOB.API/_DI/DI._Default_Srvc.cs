
using GLOB.API.Config.DI;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
public static void Add_API_Default_Srvc(this IServiceCollection srvc, IConfiguration config)
{
    srvc.Config_Localization(config);

    srvc.Config_Controllerz(config);

    srvc.AddAuthentication();
    srvc.AddAuthorization();

    srvc.Config_Swagger(config);
    srvc.Config_Cors();
    // srvc.AddAutoMapper(typeof(API_Base_Mapper));
}

public static void Add_API_Default_Srvc2(this IServiceCollection srvc)
{
    srvc.Config_Versioning();
    srvc.Config_HttpCacheHeaders();
    srvc.Config_RateLimiting();
    // srvc.Config_FileHandling();
}

}