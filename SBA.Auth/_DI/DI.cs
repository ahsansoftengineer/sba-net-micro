using GLOB.Infra.Data;
using GLOB.Infra.Data.Auth;
using GLOB.Infra.UOW_Projectz;
using GLOB.Infra.DI;
using SBA.Auth.Services;
using SBA.Projectz.Data;
using SBA.Projectz.Mapper;
using Microsoft.Extensions.Options;

namespace SBA.Projectz.DI;
public static class Projectz_DI
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_DB_SQL<DBCntxt, IUOW_Infra, UOW_Projectz>(config);
    srvc.Config_DB_Identity<ProjectzDBCntxt, IUOW_Projectz, UOW_Projectz>(config);
    srvc.AddAutoMapper(typeof(ProjectzMapper));
    
    srvc.Configure<IOptions<EmailSettings>>(config.GetSection(EmailSettings.SectionName));
    srvc.Configure<IOptions<JwtSettings>>(config.GetSection(JwtSettings.SectionName));

    srvc.AddTransient<SmtpEmailSender>();

    srvc.AddTransient<ITokenService, TokenService>();

  }
}