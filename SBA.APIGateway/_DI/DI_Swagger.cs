using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  // http://localhost:5806/api/Hierarchy/v1/swagger/index.html
  // http://localhost:5806/api/Hierarchy/v1/swagger/v1/swagger.json
  public static void Config_Swagger(this IServiceCollection services, IConfiguration config)
  {
    string hostName = config.GetValue<string>("ASPNETCORE_URLS") ?? "https://localhost:5806";
    string prefix = config.GetValue<string>("ASPNETCORE_ROUTE_PREFIX") ?? "api/Hierarchy/v1";
    string projectzName = config.GetValue<string>("ASPNETCORE_PROJECTZ_NAME") ?? "Hierarchy";

    services.AddSwaggerGen(c =>
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

    string prefix = config.GetValue<string>("ASPNETCORE_ROUTE_PREFIX") ?? "api/Hierarchy/v1";
    string projectzName = config.GetValue<string>("ASPNETCORE_PROJECTZ_NAME") ?? "MyProject";

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
    });
  }
}