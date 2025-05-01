using GLOB.Infra.Data.Auth;
using SBA.Auth.Services;
using Microsoft.Extensions.Options;

namespace SBA.Projectz.DI;
public static partial class Projectz_DI
{
  public static void Config_Options(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Configure<IOptions<EmailSettings>>(config.GetSection(EmailSettings.SectionName));

    srvc.Configure<IOptions<JwtSettings>>(config.GetSection(JwtSettings.SectionName));
    srvc.Configure<IOptions<IdentitySettings>>(config.GetSection(IdentitySettings.SectionName));
  }
}
