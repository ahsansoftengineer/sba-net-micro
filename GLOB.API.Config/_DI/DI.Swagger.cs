using GLOB.API.Config.Configz;
using GLOB.API.Config.OptionSetup;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLOB.API.Config.DI;
public static partial class API_DI_Common
{
  // http://localhost:5806/api/Hierarchy/v1/swagger/index.html
  // http://localhost:5806/api/Hierarchy/v1/swagger/v1/swagger.json
  public static void Config_Swagger(this IServiceCollection services, IConfiguration config)
  {
    string hostName = config.GetValueStr("ASPNETCORE_URLS"); // http://localhost:5806
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX"); // "api/Hierarchy/v1";
    string projectzName = config.GetValueStr("ASPNETCORE_PROJECTZ_NAME"); // "Hierarchy";

    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("swagger-doc", new OpenApiInfo
      {
        Title = projectzName,
        Version = "v1",
        Description = $"Host: {hostName}, Prefix: {prefix}, ProjectName: {projectzName}"
      });

      c.SchemaFilter<SwaggerNullablePrimitivesDataTypes>();
      c.UseAllOfToExtendReferenceSchemas();
      c.SupportNonNullableReferenceTypes();
      c.IgnoreObsoleteProperties(); // [Obsolete]

      // Add JWT Authentication to Swagger
      // Config_Swagger_JWT(c);
    });
  }

  private static void Config_Swagger_JWT(SwaggerGenOptions c)
  {
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
      Scheme = "bearer",
      BearerFormat = "JWT",
      Name = "Authorization",
      In = ParameterLocation.Header,
      Type = SecuritySchemeType.Http,
      Description = "Enter JWT Bearer token **_only_**",

      Reference = new OpenApiReference
      {
        Id = JwtBearerDefaults.AuthenticationScheme,
        Type = ReferenceType.SecurityScheme
      }
    };

    c.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
      {
          { jwtSecurityScheme, Array.Empty<string>() }
      });
  }

  public static void Config_Swagger(this IApplicationBuilder app, Action<SwaggerUIOptions> action = null)
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
      if (action != null)
      {
        action.Invoke(c);
      }
    });
  }
}