using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GLOB.API.DI;
public static partial class DICommon
{

  public static IServiceCollection AddDICommon(this IServiceCollection services)
  {
    // API Throttling 1: Adding Service
    // services.AddMemoryCache(); // Enable Production
    // API Throttling 3
    // services.ConfigureRateLimiting();
    // services.AddHttpContextAccessor();
    // API Caching 6: Adding Services Extensions
    // services.ConfigureHttpCacheHeaders();
    // services.AddAuthentication();
    // services.ConfigureIdentity();
    // services.ConfigureCors();
    //services.AddAutoMapper(typeof(MapperInitializer)); // Later
    // Transient Means Fresh Copy
    // services.ConfigureSwagger();
    services.ConfigureControllerz();
    // services.ConfigureVersioning();
    // services.ConfigureFileHandling();
    return services;
  }
  public static void ConfigureControllerz(this IServiceCollection services)
  {
    services
      // API Caching 3. Defining Cache Profile
      .AddControllers(config =>
      {
        //config.Filters<Filters>();
        config.CacheProfiles.Add("120SecondsDuration", new CacheProfile
        {
          Duration = 100
          //,Location = ResponseCacheLocation.Client
          //,NoStore = true
          //,VaryByHeader = "I don't know which string"
          //,VaryByQueryKeys = "Any Keys"
        });
      })
      .AddNewtonsoftJson(opt =>
      {
        opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        opt.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
      });

  }
  public static void ConfigureSwagger(this IServiceCollection services, string title = "Micro")
  {
    services.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
      {
        Title = title,
        Version = "v1"
      });
      //c.IgnoreObsoleteProperties();
      //c.SchemaFilter<MySwaggerSchemaFilter>(); // Failed to apply this
    });
  }
  public static void ConfigureCors(this IServiceCollection services)
  {
    services.AddCors(option =>
    {
      option
      .AddPolicy("CorsPolicyAllowAll", builder =>
        builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader()
      //.AllowCredentials()
      );
    });
    services.AddHttpsRedirection(options =>
    {
      options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
      options.HttpsPort = 443; // Replace with your HTTPS port number if different
    });
    //services.AddCors(options =>
    //{
    //  options.AddPolicy(MyAllowSpecificOrigins,
    //            policy =>
    //            {
    //              policy.WithOrigins("http://example.com",
    //                      "http://www.contoso.com")
    //                      .AllowAnyHeader()
    //                      .AllowAnyMethod();
    //            });
    //});

  }

}