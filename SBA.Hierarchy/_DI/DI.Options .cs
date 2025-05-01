namespace SBA.Projectz.DI;
public static partial class Projectz_DI
{
  public static void Config_Options(this IServiceCollection srvc, IConfiguration config)
  {
    // srvc.Configure<IOptions<EmailSettings>>(config.GetSection(EmailSettings.SectionName));
  }
}