using Microsoft.Extensions.FileProviders;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  public static void Config_StaticFilesHandling(this IApplicationBuilder app)
  {
    var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "assets");
    app.UseStaticFiles(new StaticFileOptions
    {
      FileProvider = new PhysicalFileProvider(staticFilesPath),
      RequestPath = "/assets"
    });
  }
  public static void Config_FileHandling(this IServiceCollection srvc)
  {
    srvc.Configure<IISServerOptions>(options =>
    {
      options.MaxRequestBodySize = int.MaxValue;
    });
  }
}