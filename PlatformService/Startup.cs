using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

namespace PlatformService;
public class Startup
{
  private readonly IConfiguration _config;

  public Startup(IConfiguration config)
  {
    _config = config;
  }
  public void ConfigureServices(IServiceCollection srvc)
  {
    srvc.AddDbContext<AppDbContext>(opt => {
      opt.UseInMemoryDatabase("InMem");
    });
    srvc.AddControllers(); 
    srvc.AddAutoMapper(
      AppDomain.CurrentDomain.GetAssemblies()
    );
    srvc.AddScoped<IPlatformRepo, PlatformRepo>();
    srvc.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

    srvc.AddEndpointsApiExplorer(); 
    srvc.AddSwaggerGen();
    Console.WriteLine($"--> CommandService Endpoint {_config["CommandService"]}");
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment() || true)
    {
      app.UseDeveloperExceptionPage();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform Service");
        c.RoutePrefix =  "swagger"; // string.Empty; // Optional: Serve Swagger UI at the app's root
      });
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers(); 
      // Map controller endpoints
    });

    PrepDb.PrepPopulation(app);
  }
}
