using GLOB.Infra.Data;
using GLOB.Infra.UOW_Projectz;
using GLOB.INFRA.DI;
using SBA.Projectz.Data;
using SBA.Projectz.Mapper;
using SBA.Projectz.Services;

namespace SBA.Projectz.DI;
public static class Projectz_DI
{
  public static void Add_Projectz_Srvc(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Config_DB_SQL<DBCntxt, IUOW_Infra, UOW_Projectz>(config);
    srvc.Config_DB_Identity<ProjectzDBCntxt, IUOW_Projectz, UOW_Projectz>(config);
    srvc.AddAutoMapper(typeof(ProjectzMapper));
    
    srvc.Configure<EmailSettings>(config.GetSection("EmailSettings"));
    srvc.AddTransient<SmtpEmailSender>();

  }
}