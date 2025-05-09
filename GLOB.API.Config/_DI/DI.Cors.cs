namespace GLOB.API.Config.DI;
public static partial class DI_API_Config
{
  public static void Config_Cors_Gateway(this IServiceCollection srvc)
  {
    srvc.AddCors(opt =>
    {
      opt.AddDefaultPolicy(opt => 
        opt
          .AllowAnyHeader()
          .AllowAnyOrigin()
          .AllowAnyMethod()
      );
    });
  }
  public static void Config_Cors(this IServiceCollection srvc)
  {
    srvc.AddCors(opt =>
    {
      opt.AddPolicy("PolicyAllowGateway",
        builder => builder
          .WithOrigins("http://localhost:5800", "https://localhost:5801")
          .AllowAnyHeader()
          .AllowAnyMethod());
    });
  }
}