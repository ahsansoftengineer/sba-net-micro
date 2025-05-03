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
}