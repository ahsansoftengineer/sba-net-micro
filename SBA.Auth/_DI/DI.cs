using GLOB.Infra.Data;
using GLOB.Infra.UOW_Projectz;
using SBA.Auth.Services;
using SBA.Projectz.Data;
using SBA.Projectz.Mapper;
using GLOB.Infra.Services;
using GLOB.Infra.Data.Auth;
using GLOB.Infra.DI;

namespace SBA.Projectz.DI;
public static partial class Projectz_DI
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_Options(config);
    
    srvc.Config_DB_SQL<DBCntxt, IUOW_Infra, UOW_Projectz>(config);
    srvc.Config_DB_SQL<DBCntxtIdentity, IUOW_Infra, UOW_Projectz>(config);
    srvc.Config_DB_Identity<ProjectzDBCntxt, IUOW_Projectz, UOW_Projectz>(config);
    srvc.AddAutoMapper(typeof(ProjectzMapper));

    srvc.AddTransient<SmtpEmailSender>();
    srvc.AddTransient<ITokenService, TokenService>();
  }
}
