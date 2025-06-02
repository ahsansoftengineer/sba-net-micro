using GLOB.Infra.UOW_Projectz;
using SBA.Projectz.Data;
using GLOB.Infra.DI;
using GLOB.API.Config.DI;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Add_Projectz_Config_Options(config);

    //srvc.Add_Localization(config);
    srvc.Add_Controller(config);

    srvc.Add_Authentication_JWT(config)
        .Config_Social_Auth(config);
    srvc.Add_Authorization_JWT(config);

    srvc.Add_Swagger(config);
    srvc.Add_Cors();
    // srvc.Add_DB_SQL_Identity<DBCtxIdentity, IUOW_Projectz, UOW_Projectz>(config);
    srvc.Add_DB_SQL<DBCtxProjectzInfra, IUOW_Infra, UOW_Projectz>(config);
    srvc.Add_DB_SQL_Identity<DBCtxProjectz, IUOW_Projectz, UOW_Projectz>(config);
    srvc.Config_Post_Authentication_JWT_Option();
    // srvc.AddAuthorization();
    

    srvc.Add_Projectz_Local_Srvc();
    
  }
}
