
namespace GLOB.API.DI;
public static partial class DICommon
{
  public static void Config_Cors(this IServiceCollection srvc)
  {
    srvc.AddCors(option =>
    {
      option.AddDefaultPolicy(option => option.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod());
      // option
      // .AddPolicy("CorsPolicyAllowAll", builder =>
      //   builder
      //   .AllowAnyOrigin()
      //   .AllowAnyMethod()
      //   .AllowAnyHeader()
      // .AllowCredentials()
      // );
    });
    // srvc.AddHttpsRedirection(options =>
    // {
    //   options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
    //   options.HttpsPort = 443; // Replace with your HTTPS port number if different
    // });
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