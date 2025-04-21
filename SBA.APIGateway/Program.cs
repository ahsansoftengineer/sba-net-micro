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

        // Example condition based on env or port
        var useHttps = Environment.GetEnvironmentVariable("USE_HTTPS") == "true";

        var fileName = useHttps ? "ocelot.https.json" : "ocelot.http.json";
        config.AddJsonFile(fileName, optional: false, reloadOnChange: true);
      })
      .ConfigureWebHostDefaults(webBuilder =>
      {
        webBuilder.UseStartup<Startup>();
      });
}
