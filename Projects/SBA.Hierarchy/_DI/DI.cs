using GLOB.Infra.Data;
using GLOB.Infra.UOW_Projectz;
using GLOB.Infra.DI;
using SBA.Projectz.Data;
using SBA.Projectz.Mapper;
using GLOB.API.DI;
using GLOB.API.Config.DI;

namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Add_Projectz_Config_Options(config);

    srvc.Add_API_Default_Srvc(config);
    // srvc.Add_API_Default_Srvc2();
    
    srvc.Add_DB_SQL<DBCtxProjectzInfra, IUOW_Infra, UOW_Projectz>(config);
    srvc.Add_DB_SQL<DBCtxProjectz, IUOW_Projectz, UOW_Projectz>(config);

    // srvc.Config_Post_Authentication_JWT_Option(); // Because of Identity
    srvc.AddAutoMapper(typeof(ProjectzMapper));
  }
}