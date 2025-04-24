using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;
using SBA.APIGateway.Model;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;
using GLOB.APIGateway.DI;

namespace SBA.APIGateway;

public class Startup
{
  private IConfiguration _config { get; }

  public Startup(IConfiguration configuration)
  {
    _config = configuration;
  }

  public void ConfigureServices(IServiceCollection srvc)
  {
        // Bind swagger config list
    srvc.Configure<List<SwaggerService>>(_config.GetSection("SwaggerServices"));
    srvc.Configure<SwaggerService>(_config.GetSection("SwaggerOcelot"));
    srvc.Add_API_Default_Srvc(_config);
    // srvc.Add_API_Default_Srvc2();
    srvc.AddCors(options =>
    {
      options.AddPolicy("AllowApiGateway", builder =>
      {
        builder
        .AllowAnyOrigin()
        // WithOrigins("http://localhost:5801")
        .AllowAnyHeader()
        .AllowAnyMethod();
      });
    });

    srvc.AddControllers();





    // Ocelot Gateway
    srvc.AddOcelot(_config);

    // Swagger for the gateway itself
    srvc.AddSwaggerGen(c =>
    {
      // c.SchemaFilter<SwaggerNullablePrimitivesDataTypes>();
      c.SwaggerDoc("v1", new OpenApiInfo
      {
        Title = "SBA API Gateway",
        Version = "v1",
        Description = "API Gateway routing via Ocelot"
      });
      //   c.UseAllOfToExtendReferenceSchemas();
      //   c.SupportNonNullableReferenceTypes();
      //   c.IgnoreObsoleteProperties(); // [Obsolete]
    });
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<List<SwaggerService>> swaggerOptions, IOptions<SwaggerService> SwaggerOcelot)
  {
    app.Add_API_Default_Middlewares();
    // app.UseHttpsRedirection();
    app.UseRouting();
    app.UseAuthorization();

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
      // API Gateway Ocelot Swagger
      c.SwaggerEndpoint(SwaggerOcelot.Value.Url, SwaggerOcelot.Value.Name);
      // c.DocExpansion(DocExpansion.None);
      foreach (var service in swaggerOptions.Value)
      {
        c.SwaggerEndpoint(service.Url, service.Name);
      }
    });

    // app.UseCors("AllowApiGateway");

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
    });

    app.UseOcelot();
  }
}
