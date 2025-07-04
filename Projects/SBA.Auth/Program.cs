using Serilog;

namespace SBA.Auth;
public class Program
{
  public static void Main(string[] args)
  {
    try
    {
      CreateHostBuilder(args).Build().Run();
    }
    catch (Exception e)
    {
      Console.WriteLine(e.Message);
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