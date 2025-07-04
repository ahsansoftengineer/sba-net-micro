using Serilog;
using Serilog.Events;
using Serilog.Sinks.SystemConsole.Themes;

namespace GLOB.API.Config.DI;
public static partial class DI_API_Config
{
  public static void Reg_API_Config_Serilog()
  {
    // Verbose,Debug,Information,Warning,Error,Fatal
    Log.Logger = new LoggerConfiguration()
      .MinimumLevel.Debug() // or Information in production
      .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
      .Enrich.FromLogContext()
      .WriteTo.Console(
          outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}",
          theme: AnsiConsoleTheme.Sixteen
      )
      .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
      .CreateLogger();
  }
}