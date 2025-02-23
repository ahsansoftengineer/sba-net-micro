using GLOB.API.DI;
using GLOB.Apps.Common;
using GLOB.Infra.Context;
using GLOB.Infra.UOW;
using SBA.Projectz.Data;

namespace SBA.Projectz.DI;
public static class DI
{
  public static void AddSrvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_DB_SQL<DBCntxt, IUnitOfWorkz, UnitOfWorkz>(config);
    srvc.Config_DB_SQL<DBCntxtProj, IUOW, UOW>(config);
  }
}