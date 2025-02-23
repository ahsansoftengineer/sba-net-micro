namespace SBA.Auth.DI;
public static class DI
{
  public static void AddSrvc(this IServiceCollection srvc, IConfiguration config)
  {
    // srvc.Config_DB_SQL<DBCntxt, IUnitOfWorkz, UnitOfWorkz>(config);
    // srvc.Config_DB_SQL<AppDBContextProj, IUOW, UOW>(config);
  }
}