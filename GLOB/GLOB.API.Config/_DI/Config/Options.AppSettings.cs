namespace GLOB.API.Config.Optionz;

public class Option_App
{
  // public static string? SectionName = "Option_App";
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

  public Option_Clientz Clientz { get; set; }
}


