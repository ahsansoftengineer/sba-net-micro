using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;
using SBA.APIGateway.Model;
using Microsoft.Extensions.Options;
using GLOB.API.DI;

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

    
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    app.Add_API_Default_Middlewares();
    

    app.UseOcelot();
  }
}
