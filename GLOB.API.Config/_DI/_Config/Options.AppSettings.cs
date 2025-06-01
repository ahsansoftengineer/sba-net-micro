namespace GLOB.API.Config.Configz;

public class AppSettings
{
  public static string? SectionName = "AppSettingsc";
  public Logging? Logging { get; set; }
  public string? AllowedHosts { get; set; }
  public bool? USE_HTTPS { get; set; }
  public string? ASPNETCORE_URLS { get; set; }
  public string? ASPNETCORE_HTTPS_PORT { get; set; }
  public string? DOTNET_ENVIRONMENT { get; set; }
  public string? ASPNETCORE_PROJECTZ_NAME { get; set; }
  public string? ASPNETCORE_ROUTE_PREFIX { get; set; }
  public JwtSettings? JwtSettings { get; set; }

  public ConnectionStrings? ConnectionStrings { get; set; }

  public SrvcHttp? SrvcHttp { get; set; }
  public SrvcGRPC? SrvcGRPC { get; set; }
  public SrvcRabbitMQ? SrvcRabbitMQ { get; set; }
}