using GLOB.API.Config.DI;

namespace GLOB.API.DI;

public static partial class DI_API
{
  public static void Add_API_Default_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    //srvc.Add_API_Config_Localization(config);
    // srvc.Add_API_Config_Options(config);
    DI_API_Config.Reg_API_Config_Serilog();
    srvc.Add_API_Controller_Srvc_Extend(config);

    srvc.Add_API_Config_Authentication_JWT(config);
    srvc.Add_API_Config_Authorization_JWT(config);

    srvc.Add_API_Config_Swagger(config);
    srvc.Add_API_Config_Cors();
    // srvc.AddAutoMapper(typeof(API_Base_Mapper));
  }

  public static void Add_API_Default_Srvc2(this IServiceCollection srvc)
  {
    srvc.Add_API_Config_Versioning();
    srvc.Add_API_Config_HttpCacheHeaders();
    srvc.Add_API_Config_RateLimiting();
    // srvc.Add_API_Config_StaticFiles();
  }

}