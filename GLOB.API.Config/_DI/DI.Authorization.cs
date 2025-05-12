namespace GLOB.API.Config.DI;
public static partial class DI_API_Config
{
  public static void Config_Authorization_JWT(this IServiceCollection srvc, IConfiguration config)
  {
    srvc.AddAuthorization(options =>
    {
      options.AddPolicy("Policy-Admin", policy => policy.RequireRole("Admin"));
      options.AddPolicy("Policy-Customer", policy => policy.RequireRole("Customer"));
    });
  }
}