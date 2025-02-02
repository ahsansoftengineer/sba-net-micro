using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;



namespace GLOB.API.DI;
public static partial class DICommon
{

  public static IServiceCollection AddDICommon(this IServiceCollection srvc)
  {
    // API Throttling 1: Adding Service
    // srvc.AddMemoryCache(); // Enable Production
    // API Throttling 3
    // srvc.ConfigureRateLimiting();
    // srvc.AddHttpContextAccessor();
    // API Caching 6: Adding Services Extensions
    // srvc.ConfigureHttpCacheHeaders();
    // srvc.AddAuthentication();
    // srvc.ConfigureIdentity();
    // srvc.ConfigureCors();
    //srvc.AddAutoMapper(typeof(MapperInitializer)); // Later
    // Transient Means Fresh Copy
    srvc.ConfigureSwagger();
    srvc.ConfigureControllerz();
    // srvc.ConfigureVersioning();
    // srvc.ConfigureFileHandling();
    return srvc;
  }
  public static void ConfigureControllerz(this IServiceCollection srvc)
  {
    srvc
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
  public static void ConfigureSwagger(this IServiceCollection srvc)
  {
    srvc.AddSwaggerGen(c =>
    {
      c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
      {
        Title = "Micro",
        Version = "v1"
      });
      //c.IgnoreObsoleteProperties();
      //c.SchemaFilter<MySwaggerSchemaFilter>(); // Failed to apply this
    });
  }
  public static void ConfigureCors(this IServiceCollection srvc)
  {
    srvc.AddCors(option =>
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
    srvc.AddHttpsRedirection(options =>
    {
      options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
      options.HttpsPort = 443; // Replace with your HTTPS port number if different
    });
    //srvc.AddCors(options =>
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