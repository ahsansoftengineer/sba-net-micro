using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;
using SBA.APIGateway.Model;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SBA.APIGateway;

public class Startup
{
  public IConfiguration Configuration { get; }

  public Startup(IConfiguration configuration)
  {
    Configuration = configuration;
  }

  public void ConfigureServices(IServiceCollection services)
  {
    services.AddCors(options =>
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

    services.AddControllers();

    // Bind swagger config list
    services.Configure<List<SwaggerService>>(Configuration.GetSection("SwaggerServices"));
    services.Configure<SwaggerService>(Configuration.GetSection("SwaggerOcelot"));



    // Ocelot Gateway
    services.AddOcelot(Configuration);

    // Swagger for the gateway itself
    services.AddSwaggerGen(c =>
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
    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
    }

    app.UseHttpsRedirection();
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

    app.UseCors("AllowApiGateway");

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
    });

    app.UseOcelot();
  }
}
