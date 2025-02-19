using GLOB.API.DI;
using GLOB.Apps.Common;
using GLOB.Infra.Common;
using SBA.Hierarchy.App;
using SBA.Hierarchy.Context;
using SBA.Hierarchy.Infra;

namespace SBA.Hierarchy.DI;
public static class DI
{
  public static void AddSrvc(this IServiceCollection srvc, IConfiguration config)
  {
    // srvc.Config_DB_SQL<AppDBContextz, IUnitOfWorkz, UnitOfWorkz>(config);
    srvc.Config_DB_SQL<AppDBContextProj, IUOW, UOW>(config);
  }
}