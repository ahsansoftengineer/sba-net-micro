using GLOB.Domain.Common;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.FileProviders;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace GLOB.API.DI;
public static partial class DICommon
{
  public static void Config_EP(this IApplicationBuilder app)
  {
    app.UseEndpoints(ep =>
    {
      // This Routing is useful for MVC type application
      // Convention Based Routing Schema
      //ep.MapControllerRoute(
      //  name: "default",
      //  pattern: "{controller=Home}/{action=Index}/{id?}"); //
      ep.MapControllers();
    });
  }
  public static void Config_DevEnv(this IApplicationBuilder app, IWebHostEnvironment env)
  {

    if (env.IsDevelopment())
    {
      app.UseDeveloperExceptionPage();
      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Trevor v1");
        c.DocExpansion(DocExpansion.None);
        //c.InjectJavascript("/js/swagger-custom.js"); //
      });
    }
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

  // FILES HANDING ###############
  public static void Config_StaticFilesHandling(this IApplicationBuilder app)
  {
    // https://localhost:5001/FooterImg348db3b7-e6dc-47f6-8bcd-74f6a35e7859.jpg
    // https://localhost:5001/assets/ouz/FooterImg348db3b7-e6dc-47f6-8bcd-74f6a35e7859.jpg
    // Optional: Serve files from a custom directory

    app.UseStaticFiles();
    var staticFilesPath = Path.Combine(Directory.GetCurrentDirectory(), "assets");
    app.UseStaticFiles(new StaticFileOptions
    {
      FileProvider = new PhysicalFileProvider(staticFilesPath),
      RequestPath = "/assets"
    });
  }
  public static void Config_FileHandling(this IServiceCollection srvc)
  {
    srvc.Configure<IISServerOptions>(options =>
    {
      options.MaxRequestBodySize = int.MaxValue; // Set the maximum request body size (e.g., unlimited)
    });

    // srvc.AddHttpContextAccessor();// Already Config_d
    // srvc.AddScoped<FileUploderz, FileUploderz>();
  }
}