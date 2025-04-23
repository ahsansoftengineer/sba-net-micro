using GLOB.API.Configz;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  public static void Config_Swagger(this IServiceCollection srvc, IConfiguration config)
  {
    string hostName = config.GetValueStr("ASPNETCORE_URLS");
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    string projectzName = config.GetValueStr("ASPNETCORE_PROJECTZ_NAME");
    srvc.AddSwaggerGen(c =>
    {
      // c.AddServer(new OpenApiServer
      // {
      //   Url = $"{hostName}/{prefix}/swagger" // API Gateway base path
      // });
      c.SchemaFilter<SwaggerNullablePrimitivesDataTypes>();
      // c.SchemaFilter<KebabCaseSchemaFilter>();
      c.SwaggerDoc("v1", new OpenApiInfo
      {
        Title = projectzName,
        Version = "v1",
        Description = $"Host : {hostName}, Prefix {prefix}, ProjectName {projectzName}"
      });
      c.UseAllOfToExtendReferenceSchemas();
      c.SupportNonNullableReferenceTypes();
      c.IgnoreObsoleteProperties(); // [Obsolete]
    });
  }
  public static void Config_Swagger(this IApplicationBuilder app)
  {
    IConfiguration config = app.GetSrvc<IConfiguration>();
    string hostName = config.GetValueStr("ASPNETCORE_URLS");
    string prefix = config.GetValueStr("ASPNETCORE_ROUTE_PREFIX");
    string projectzName = config.GetValueStr("ASPNETCORE_PROJECTZ_NAME");
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      // c.SwaggerEndpoint("/swagger/swagger.json", projectzName);
      c.DocumentTitle = $"Host : {hostName}, Prefix {prefix}, ProjectName {projectzName}";
      c.DocExpansion(DocExpansion.None);
      // c.RoutePrefix = prefix;
        //c.InjectJavascript("/js/swagger-custom.js"); //
    });
  }
  


}