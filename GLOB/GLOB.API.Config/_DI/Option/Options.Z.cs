namespace GLOB.API.Config.Optionz;

public class Logging
{
    public static string SectionName = "Logging";
    public LogLevel? LogLevel { get; set; }
}

public class LogLevel
{
    public static string SectionName = "LogLevel";
    public string? Default { get; set; }
    public string? MicrosoftAspNetCore { get; set; }
}

public class Option_ConnectionStrings
{
    public static string SectionName = "ConnectionStrings";
    public string? SqlConnection { get; set; }
    public string? Redis { get; set; }
    public string? SQLite { get; set; }
}