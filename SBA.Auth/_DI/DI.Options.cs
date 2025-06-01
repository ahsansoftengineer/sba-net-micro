using GLOB.Infra.Data.Auth;
using SBA.Auth.Services;
using GLOB.API.Config.Configz;

namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{
  public static void Config_Options(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Configure<EmailSettings>(config.GetSection(EmailSettings.SectionName));
    srvc.Configure<JwtSettings>(config.GetSection(JwtSettings.SectionName));
    srvc.Configure<IdentitySettings>(config.GetSection(IdentitySettings.SectionName));
    srvc.Configure<SocialAccounts>(config.GetSection(SocialAccounts.SectionName));
  }
}
