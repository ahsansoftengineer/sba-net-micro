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
  public static void Config_Gateway_Swagger(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Configure<List<SwaggerService>>(config.GetSection("SwaggerServices"));
    srvc.Config_Swagger(config);
  }

  public static void Config_Swagger_Gateway(this IApplicationBuilder app)
  {
    app.Config_Swagger();

    app.UseSwaggerUI(c =>
    {
      var URLProjects = app.GetSrvc<IOptions<List<SwaggerService>>>().Value;
      foreach (var service in URLProjects)
      {
        c.SwaggerEndpoint(service.Url, service.Name);
      }
    });
  }
}