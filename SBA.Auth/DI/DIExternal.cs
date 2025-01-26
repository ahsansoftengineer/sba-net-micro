using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace ProjectName.API.DI;
public static partial class DIExternal
{
  public static IServiceCollection AddExternalServices(this IServiceCollection services)
  {
    services
    .ConfigureIdentity()
    .ConfigureVersioning()
    //.ConfigureHttpCacheHeaders() // Enable on Production
    .ConfigureRateLimiting();
    services.ConfigureFileHandling();
    return services;
  }
  public static IApplicationBuilder AddExternalConfiguration(this IApplicationBuilder app,
    IWebHostEnvironment env)
  {
    app.ConfigureStaticFilesHandling();
    app.ConfigureDevEnv(env);
    app.ConfigureExceptionHandler();
    app.UseHttpsRedirection();

    app.UseCors("CorsPolicyAllowAll");

    // API Caching 2. Setting up Caching
    //app.UseResponseCaching(); // Enable Production
    // API Caching 7. Setting up Caching Profile at Globally
    //app.UseHttpCacheHeaders(); // Enable Production
    // API Throttling 4. Setting up Middleware
    // This is giving error while running
    //app.UseIpRateLimiting(); // Prevent Unnecessary Http Call from same User

    app.UseRouting();
    app.UseAuthorization();
    app.UseEndpoints(ep =>
    {
      // This Routing is useful for MVC type application
      // Convention Based Routing Schema
      //ep.MapControllerRoute(
      //  name: "default",
      //  pattern: "{controller=Home}/{action=Index}/{id?}"); //
      ep.MapControllers();
    });

    return app;
  }
  public static void ConfigureStaticFilesHandling(this IApplicationBuilder app)
  {
    app.UseStaticFiles(); // Enable static file serving
                // https://localhost:5001/FooterImg348db3b7-e6dc-47f6-8bcd-74f6a35e7859.jpg
                // https://localhost:5001/assets/ouz/FooterImg348db3b7-e6dc-47f6-8bcd-74f6a35e7859.jpg
                // Optional: Serve files from a custom directory
    var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "assets");
    app.UseStaticFiles(new StaticFileOptions
    {
      FileProvider = new PhysicalFileProvider(staticFilesPath),
      RequestPath = "/assets"
    });
  }
  public static void ConfigureDevEnv(this IApplicationBuilder app, IWebHostEnvironment env)
  {

    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trevor v1");
        c.DocExpansion(DocExpansion.None);
        //c.InjectJavascript("/js/swagger-custom.js"); //
      });
    }
  }
  public static IApplicationBuilder ConfigureExceptionHandler(this IApplicationBuilder app)
  {
    app.UseExceptionHandler(error =>
    {
      error.Run(async context =>
    {
      context.Response.StatusCode = StatusCodes.Status500InternalServerError;
      context.Response.ContentType = "application/json";
      var contextFeature = context.Features.Get<IExceptionHandlerFeature>();

      if (contextFeature != null)
      {
        //Log.Error($"Something Went Wrong in the {contextFeature.Error}"); //

        await context.Response.WriteAsync(new Error
        {
          StatusCode = context.Response.StatusCode,
          Message = "Internal Server Error. Please Try Again Later."
        }.ToString());
      }
    });
    });
    return app;
  }
  // Entity Framework Identity
  public static IServiceCollection ConfigureIdentity(this IServiceCollection services)
  {
    var builder = services
    .AddIdentityCore<ApiUser>(q => q.User.RequireUniqueEmail = true);
    builder = new IdentityBuilder(
    builder.UserType,
    typeof(IdentityRole), services);

    builder
    .AddEntityFrameworkStores<DBCntxt>()
      .AddDefaultTokenProviders();
    return services;
  }
  // Version URI, Query, Headers
  public static IServiceCollection ConfigureVersioning(this IServiceCollection services)
  {
    services.AddApiVersioning(opt =>
    {
      opt.ReportApiVersions = true;
      opt.AssumeDefaultVersionWhenUnspecified = true;
      opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    });
    return services;
  }
  // API Caching : 5 with Marvin.Cache.Headers
  public static IServiceCollection ConfigureHttpCacheHeaders(this IServiceCollection services)
  {
    services.AddResponseCaching();
    services.AddHttpCacheHeaders(
    (expirationOpt) =>
    {
      expirationOpt.MaxAge = 65;
      expirationOpt.CacheLocation = Marvin.Cache.Headers.CacheLocation.Private;
    },
    (validationOpt) =>
    {
      validationOpt.MustRevalidate = true;
    }
    );
    return services;
  }
  // API Throttling 2: 
  public static IServiceCollection ConfigureRateLimiting(this IServiceCollection services)
  {
    var rateLimitRules = new List<RateLimitRule>
  {
  new RateLimitRule
  {
    Endpoint = "*",
    Limit = 10,
    Period = "1m"
  }
  };

    services.Configure<IpRateLimitOptions>(opt =>
    {
      opt.GeneralRules = rateLimitRules;
    });
    services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
    services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
    services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

    return services;
  }
  public static void ConfigureFileHandling(this IServiceCollection services)
  {
    services.Configure<IISServerOptions>(options =>
    {
      options.MaxRequestBodySize = int.MaxValue; // Set the maximum request body size (e.g., unlimited)
    });

    //services.AddHttpContextAccessor();// Already Configured
    services.AddScoped<FileUploderz, FileUploderz>();
  }
}