using GLOB.Infra.Data;
using GLOB.Infra.UOW_Projectz;
using SBA.Projectz.Data;
using GLOB.Infra.DI;
using GLOB.API.Config.DI;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_Options(config);

    //srvc.Config_Localization(config);
    srvc.Config_Controllerz(config);
    srvc.Add_Projectz_Auth_Srvc(config);
    srvc.Config_Swagger(config);
    srvc.Config_Cors();
    srvc.Config_DB_SQL<DBCtx, IUOW_Infra, UOW_Projectz>(config);
    // srvc.Config_DB_Identity<DBCtxIdentity, IUOW_Infra, UOW_Projectz>(config);
    srvc.Config_DB_Identity<DBCtxProjectz, IUOW_Projectz, UOW_Projectz>(config);
    srvc.Config_Post_Authentication_JWT_Option();
    // srvc.AddAuthorization();
    

    srvc.Add_Projectz_Local_Srvc();
    
  }
  public static void Add_Projectz_Auth_Srvc(this IServiceCollection srvc, IConfiguration config)
  {


    srvc.Config_Authentication_JWT(config)
        .Config_Social_Auth(config);

    srvc.Config_Authorization_JWT(config);


    // srvc.AddAutoMapper(typeof(API_Base_Mapper));
    
  }
}
