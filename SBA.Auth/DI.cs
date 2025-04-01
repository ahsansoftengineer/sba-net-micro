using GLOB.Infra.Context;
using GLOB.Infra.UOW;
using GLOB.INFRA.DI;
using SBA.Projectz.Data;
using SBA.Projectz.Mapper;

namespace SBA.Projectz.DI;
public static class DI
{
  public static void AddSrvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_DB_SQL<DBCntxt, IUnitOfWorkz, UOW>(config);
    srvc.Config_DB_Identity<DBCntxtProj, IUOW, UOW>(config);
    srvc.AddAutoMapper(typeof(MapProj));
  }
}