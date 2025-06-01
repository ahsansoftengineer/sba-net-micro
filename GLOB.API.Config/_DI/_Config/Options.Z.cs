namespace GLOB.API.Config.Configz;

public class Logging
{
    public LogLevel? LogLevel { get; set; }
}

public class LogLevel
{
    public string? Default { get; set; }
    public string? MicrosoftAspNetCore { get; set; }
}

public class ConnectionStrings
{
    public string? SqlConnection { get; set; }
}