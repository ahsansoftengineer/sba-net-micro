using Microsoft.EntityFrameworkCore;
using PlatformService.Data;
using PlatformService.SyncDataServices.Http;

namespace PlatformService;
public class Startup
{
  private readonly IConfiguration _config;
  private readonly IWebHostEnvironment _env;
  public Startup(IConfiguration config, IWebHostEnvironment env)
  {
    _config = config;
    _env = env;
  }
  public void ConfigureServices(IServiceCollection srvc)
  {
    Console.WriteLine("--> Using SqlServer DB");
    srvc.AddDbContext<AppDBContext>(opt =>
    {
      string connStr = _config.GetConnectionString("PlatformConn");
      Console.WriteLine(connStr);
      opt.UseSqlServer(connStr, sqlOptions =>
        {
          sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 1,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: null
          );
        });
        opt.LogTo(Console.WriteLine, LogLevel.Information);
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
    // env.IsDevelopment() || env.IsDev();
    if (true)
    {
      app.UseDeveloperExceptionPage();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform Service");
        c.RoutePrefix = "swagger"; // string.Empty; // Optional: Serve Swagger UI at the app's root
      });
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
    });

    app.Use(async (context, next) =>
    {
      if (context.Request.Path == "/")
      {
        context.Response.Redirect("/swagger/index.html");
        return;
      }
      await next();
    });
   
  }
}
