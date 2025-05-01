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
    IConfiguration config = app.GetSrvc<IConfiguration>();

    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    string projectzName = config.GetValueStr("ASPNETCORE_PROJECTZ_NAME");

    app.Config_StaticFilesHandling(); // Required for Swagger UI

    app.UseSwagger(c =>
    {
      c.RouteTemplate = prefix + "/{documentName}/swagger.json"; // Updated Swagger JSON path
    });

    app.UseSwaggerUI(c =>
    {
      c.DocumentTitle = $"Swagger UI {projectzName}";
      c.RoutePrefix = $"{prefix}/swagger"; // Swagger UI will be served under this path
      c.SwaggerEndpoint($"/{prefix}/swagger-doc/swagger.json", $"{projectzName} - v1"); // Updated Swagger JSON URL
      c.DocExpansion(DocExpansion.None);
        var Option = app.GetSrvc<IOptions<SwaggerServicesOptions>>();
      foreach (var service in Option?.Value?.Services)
      {
        Console.WriteLine(service.Name + "  --  " + service.Url);
        c.SwaggerEndpoint(service.Url, service.Name);
      }
    });
    // app.Config_Swagger();

    // app.UseSwaggerUI(c =>
    // {
    
    // });
  }
}