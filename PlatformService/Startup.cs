using Microsoft.EntityFrameworkCore;
using PlatformService.Data;

namespace PlatformService;
public class Startup
{
  public void ConfigureServices(IServiceCollection srvc)
  {
    srvc.AddDbContext<AppDbContext>(opt => {
      opt.UseInMemoryDatabase("InMem");
    });
    srvc.AddControllers(); 
    srvc.AddAutoMapper(
      AppDomain.CurrentDomain.GetAssemblies()
    );
    srvc.AddTransient<IPlatformRepo, PlatformRepo>();
    srvc.AddEndpointsApiExplorer(); 
    srvc.AddSwaggerGen();
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    if (env.IsDevelopment())
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
      endpoints.MapControllers(); // Map controller endpoints
    });

    PrepDb.PrepPopulation(app);
  }
}
