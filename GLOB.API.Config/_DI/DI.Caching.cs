using AspNetCoreRateLimit;

namespace GLOB.API.Config.DI;
public static partial class API_DI_Common
{
  public static void Config_CachingService(this IServiceCollection srvc)
  {
      // API Throttling 1: Adding Service
      // srvc.AddMemoryCache(); // Enable Production
      // API Throttling 3
      // srvc.Config_RateLimiting();
      srvc.AddHttpContextAccessor();
      // API Caching 6: Adding Services Extensions
      srvc.Config_HttpCacheHeaders();
  }
  
  // CACHING VERSIONING ######################
  public static void Config_Caching(this IApplicationBuilder app)
  {

    // API Caching 2. Setting up Caching
    // app.UseResponseCaching(); // Enable Production
    // API Caching 7. Setting up Caching Profile at Globally
    // app.UseHttpCacheHeaders(); 
    // Enable Production
    // API Throttling 4. Setting up Middleware
    // This is giving error while running
    // app.UseIpRateLimiting(); // Prevent Unnecessary Http Call from same User
  }
  
  public static void Config_Versioning(this IServiceCollection srvc)
  {
    srvc.AddApiVersioning(opt =>
    {
      opt.ReportApiVersions = true;
      opt.AssumeDefaultVersionWhenUnspecified = true;
      opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    });
  }
  // API Throttling 2: 
  public static void Config_RateLimiting(this IServiceCollection srvc)
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

    srvc.Configure<IpRateLimitOptions>(opt =>
    {
      opt.GeneralRules = rateLimitRules;
    });
    srvc.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();
    srvc.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
    srvc.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
  }
  // API Caching : 5 with Marvin.Cache.Headers
  public static void Config_HttpCacheHeaders(this IServiceCollection srvc)
  {
    srvc.AddResponseCaching();
    srvc.AddHttpCacheHeaders(
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
  }
}