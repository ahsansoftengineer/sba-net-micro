using GLOB.API.DI;
using SBA.Hierarchy.Config;

namespace SBA.Hirarchy.DI;
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
    services.AddAutoMapper(typeof(MapInitProj)); // Later
    // Transient Means Fresh Copy
    services.ConfigureSwagger("Hierarchy");
    // services.ConfigureControllerz();
    // services.ConfigureVersioning();
    // services.ConfigureFileHandling();
    return services;
  }
}