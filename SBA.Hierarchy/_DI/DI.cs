using GLOB.Infra.Data;
using GLOB.Infra.UOW_Projectz;
using GLOB.Infra.DI;
using SBA.Projectz.Data;
using SBA.Projectz.Mapper;

namespace SBA.Projectz.DI;
public static partial class Projectz_DI
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_Options(config);
    srvc.Config_DB_SQL<DBCntxt, IUOW_Infra, UOW_Projectz>(config);
    srvc.Config_DB_SQL<ProjectzDBCntxt, IUOW_Projectz, UOW_Projectz>(config);
    srvc.AddAutoMapper(typeof(ProjectzMapper));

  }
}