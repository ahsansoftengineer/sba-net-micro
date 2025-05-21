using GLOB.API.Config.DI;

namespace GLOB.API.DI;
public static partial class DI_API
{
public static void Add_API_Default_Srvc(this IServiceCollection srvc, IConfiguration config)
{
    //srvc.Add_Localization(config);

    srvc.Add_Controller(config);

    srvc.Add_Authentication_JWT(config);
    srvc.Add_Authorization_JWT(config);

    srvc.Add_Swagger(config);
    srvc.Add_Cors();
    // srvc.AddAutoMapper(typeof(API_Base_Mapper));
}

public static void Add_API_Default_Srvc2(this IServiceCollection srvc)
{
    srvc.Add_Versioning();
    srvc.Add_HttpCacheHeaders();
    srvc.Config_RateLimiting();
    // srvc.Add_StaticFiles();
}

}