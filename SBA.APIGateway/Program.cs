namespace SBA.APIGateway;
public class Program
{
  public static void Main(string[] args)
  {
    CreateHostBuilder(args).Build().Run();
  }

  public static IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
      .ConfigureAppConfiguration((hostingContext, config) =>
      {
        var env = hostingContext.HostingEnvironment;
        var builtConfig = config.Build(); // Temporarily build config to read env vars
        var ocelotFile = builtConfig["OcelotFileName"] ?? "ocelot.json";

        config.AddJsonFile(ocelotFile, optional: false, reloadOnChange: true);
      })
      .ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseStartup<Startup>();
      });
}
