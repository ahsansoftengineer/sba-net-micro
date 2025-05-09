namespace SBA.Projectz.DI;
public static partial class DI_Projectz
{
  public static void Config_Options(this IServiceCollection srvc, IConfiguration config)
  {
    // srvc.Configure<IOptions<EmailSettings>>(config.GetSection(EmailSettings.SectionName));
  }
}