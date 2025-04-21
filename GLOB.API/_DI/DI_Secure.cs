
namespace GLOB.API.DI;
public static partial class API_DI_Common
{
  public static void Config_Cors(this IServiceCollection srvc)
  {
    srvc.AddCors(opt =>
    {
      opt.AddPolicy("AllowGateway", policy =>
      {
          policy.WithOrigins("https://localhost:5801")
                .AllowAnyHeader()
                .AllowAnyMethod();
      });
      opt.AddDefaultPolicy(opt => opt.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
      // opt
      // .AddPolicy("CorsPolicyAllowAll", builder =>
      //   builder
      //   .AllowAnyOrigin()
      //   .AllowAnyMethod()
      //   .AllowAnyHeader()
      // .AllowCredentials()
      // );
    });
    // srvc.AddHttpsRedirection(opt =>
    // {
    //   opt.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    //   opt.HttpsPort = 443; // Replace with your HTTPS port number if different
    // });
    //srvc.AddCors(opt =>
    //{
    //  opt.AddPolicy(MyAllowSpecificOrigins,
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