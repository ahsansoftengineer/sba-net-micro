using SBA.Auth.Services;
using SBA.Projectz.Mapper;

namespace SBA.Projectz.DI;

public static partial class DI_Projectz
{
  public static void Add_Projectz_Local_Srvc(this IServiceCollection srvc)
  {
    srvc.AddAutoMapper(typeof(ProjectzMapper));
    srvc.AddScoped<SmtpEmailSender>();
    srvc.AddScoped<TokenService>();
  }
}