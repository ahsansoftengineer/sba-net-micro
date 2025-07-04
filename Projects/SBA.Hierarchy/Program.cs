using Serilog;

namespace SBA.Hierarchy;
public class Program
{
  public static void Main(string[] args)
  {
    //Log.Logger = new LoggerConfiguration()
    //  .WriteTo.File(
    //  path: "d:\\Trevoir\\logs\\log-.txt",
    //  outputTemplate: "{Timestamp:dd-MM-yyyy HH:mm:ss} [{Level:u3}] {Message: 1j}{NewLine}{Exception}",
    //  rollingInterval: RollingInterval.Day,
    //  restrictedToMinimumLevel: LogEventLevel.Information
    //).CreateLogger(); //
    try
    {
      //Log.Information("Application is Starting"); // 
      CreateHostBuilder(args).Build().Run();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
      //Log.Fatal(e, "Application Failed to start"); //
    }
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
    .UseSerilog()
    .ConfigureWebHostDefaults(webBuilder =>
    {
      webBuilder.UseStartup<Startup>();
    });
}