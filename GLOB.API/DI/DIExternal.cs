using AspNetCoreRateLimit;
using GLOB.Apps.Common;
using GLOB.Domain.Common;
using GLOB.Domain.Entity;
using GLOB.Infra.Common;
using GLOB.Infra.Context;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
  public static void Config_Identity(this IServiceCollection srvc)
  {
    var builder = srvc
      .AddIdentityCore<TestApiUser>(q => q.User.RequireUniqueEmail = true);
    builder = new IdentityBuilder(
      builder.UserType,
      typeof(IdentityRole), srvc);

    builder
      .AddEntityFrameworkStores<AppDBContextz>()
      .AddDefaultTokenProviders();
  }
  public static void Config_DB_SQL<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config) 
    where TContext : AppDBContextz
    where TIUOW : class, IUnitOfWorkz
    where TUOW : UnitOfWorkz, TIUOW

  {
    srvc.AddDbContext<TContext>(opt =>
    {
      string connStr = config.GetConnectionString("SqlConnection");
      opt.EnableSensitiveDataLogging(true);
      opt.UseSqlServer(connStr, sqlOptions =>
        {
          sqlOptions.EnableRetryOnFailure(
            maxRetryCount: 1,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: null
          );
        });
        opt.LogTo(Console.WriteLine, LogLevel.Information);
    });
    srvc.AddScoped<TIUOW, TUOW>();
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