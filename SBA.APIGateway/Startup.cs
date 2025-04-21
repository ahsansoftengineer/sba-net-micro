using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Microsoft.OpenApi.Models;
using SBA.APIGateway.Model;
using Microsoft.Extensions.Options;

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
        services.AddControllers();

        // Bind swagger config list
        services.Configure<List<SwaggerService>>(Configuration.GetSection("SwaggerServices"));

        // Ocelot Gateway
        services.AddOcelot(Configuration);

        // Swagger for the gateway itself
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "SBA API Gateway",
                Version = "v1",
                Description = "API Gateway routing via Ocelot"
            });
        });
    }

    public async Task Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<List<SwaggerService>> swaggerOptions)
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
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "SBA API Gateway v1");

            foreach (var service in swaggerOptions.Value)
            {
                c.SwaggerEndpoint(service.Url, service.Name);
            }
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        await app.UseOcelot();
    }
}
