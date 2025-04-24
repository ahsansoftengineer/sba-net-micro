using GLOB.API.Configz;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using SBA.APIGateway.Model;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  // http://localhost:5806/api/Hierarchy/v1/swagger/index.html
  // http://localhost:5806/api/Hierarchy/v1/swagger/v1/swagger.json
  public static void Config_Swagger(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.Configure<List<SwaggerService>>(config.GetSection("SwaggerServices"));
    srvc.Configure<SwaggerService>(config.GetSection("SwaggerOcelot"));


    string hostName = config.GetValueStr("ASPNETCORE_URLS");
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    string projectzName = config.GetValueStr("ASPNETCORE_PROJECTZ_NAME");

    srvc.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("swagger-doc", new OpenApiInfo
      {
        Title = projectzName,
        Version = "v1",
        Description = $"Host: {hostName}, Prefix: {prefix}, ProjectName: {projectzName}"
      });

      c.UseAllOfToExtendReferenceSchemas();
      c.SupportNonNullableReferenceTypes();
      c.IgnoreObsoleteProperties(); // [Obsolete]
    });
  }

  public static void Config_Swagger(this IApplicationBuilder app)
  {
    IConfiguration config = app.GetSrvc<IConfiguration>();
    var URLProjects = app.GetSrvc<IOptions<List<SwaggerService>>>().Value;
    var URLOcelot = app.GetSrvc<IOptions<SwaggerService>>().Value;

    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    string projectzName = config.GetValueStr("ASPNETCORE_PROJECTZ_NAME");

    app.Config_StaticFilesHandling(); // Required for Swagger UI

    app.UseSwagger(c =>
    {
      c.RouteTemplate = prefix + "/{documentName}/swagger.json"; // Updated Swagger JSON path
    });

    app.UseSwaggerUI(c =>
    {
      // API Gateway Ocelot Swagger
      c.SwaggerEndpoint(URLOcelot.Url, URLOcelot.Name);
      // c.DocExpansion(DocExpansion.None);
      foreach (var service in URLProjects)
      {
        c.SwaggerEndpoint(service.Url, service.Name);
      }
    });


    app.UseSwaggerUI(c =>
    {
      c.DocumentTitle = $"Swagger UI {projectzName}";
      c.RoutePrefix = $"{prefix}/swagger"; // Swagger UI will be served under this path
      c.SwaggerEndpoint($"/{prefix}/swagger-doc/swagger.json", $"{projectzName} - v1"); // Updated Swagger JSON URL
      c.DocExpansion(DocExpansion.None);
    });
  }
}