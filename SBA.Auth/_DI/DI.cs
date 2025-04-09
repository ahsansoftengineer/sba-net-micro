using GLOB.Infra.Data;
using GLOB.Infra.UOW;
using GLOB.INFRA.DI;
using SBA.Projectz.Data;
using SBA.Projectz.Mapper;

namespace SBA.Projectz.DI;
public static class Projectz_DI
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_DB_SQL<DBCntxt, IUnitOfWorkInfra, UOW>(config);
    srvc.Config_DB_Identity<ProjectzDBCntxt, IUOW, UOW>(config);
    srvc.AddAutoMapper(typeof(ProjectzMapper));
  }
}