using GLOB.API.Config.Configz;
using GLOB.API.Config.DI;
using Microsoft.Extensions.Options;
using SBA.APIGateway.Model;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  // http://localhost:5806/api/Gateway/v1/swagger/index.html
  // http://localhost:5806/api/Gateway/v1/swagger/v1/swagger.json
  public static void Config_Swagger_Gateway(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Configure<SwaggerServicesOptions>(config.GetSection("SwaggerServices"));
    srvc.Config_Swagger(config);
  }

  public static void Config_Swagger_Gateway(this IApplicationBuilder app)
  {
    app.Config_Swagger((c) => {
      var Option = app.GetSrvc<IOptions<SwaggerServicesOptions>>();
      foreach (var service in Option?.Value?.Services)
      {
        Console.WriteLine(service.Name + "  --  " + service.Url);
        c.SwaggerEndpoint(service.Url, service.Name);
      }
    });
  }
}