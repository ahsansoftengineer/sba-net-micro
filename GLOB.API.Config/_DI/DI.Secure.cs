using Microsoft.AspNetCore.Diagnostics;
using Newtonsoft.Json;

namespace GLOB.API.Config.DI;
public static partial class API_DI_Common
{
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
  public static void Config_ExceptionHandler(this IApplicationBuilder app)
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
  }

}
public class Error
{
  public int StatusCode { get; set; }
  public string Message { get; set; } = "";
  public override string ToString()
  {
    return JsonConvert.SerializeObject(this);
  }
}