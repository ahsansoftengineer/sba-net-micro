using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SBA.Auth.Data;

namespace SBA.Auth;
public class Startup
{
  private readonly IConfiguration _config;
  private readonly IWebHostEnvironment _env;
  public Startup(IConfiguration config, IWebHostEnvironment env)
  {
    _config = config;
    _env = env;
  }
  public void ConfigureServices(IServiceCollection srvc)
  {
    ConfigureServicesDB(srvc);
    srvc.AddControllers();
    // srvc.AddAutoMapper(
    //   AppDomain.CurrentDomain.GetAssemblies()
    // );
    // srvc.AddScoped<IPlatformRepo, PlatformRepo>();
    // srvc.AddHttpClient<ICommandDataClient, HttpCommandDataClient>();

    srvc.AddEndpointsApiExplorer();
    srvc.AddSwaggerGen();
    Console.WriteLine($"--> CommandService Endpoint {_config["CommandService"]}");
    Console.WriteLine($"--> SQL Connection {_config.GetConnectionString("SbPlatform")}");
  }
  public void ConfigureServicesDB(IServiceCollection srvc)
  {
    Console.WriteLine("--> Using SqlServer SbPlatform");
    string connStr = _config.GetConnectionString("SbPlatform");
    srvc.AddDbContext<AppDBContext>(opt =>
    {
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

    srvc.AddDbContext<AppDBContext>(options =>
        options.UseSqlServer(connStr));

    srvc.AddIdentity<IdentityUser, IdentityRole>()
        // .AddEntityFrameworkStores<AppDBContext>()
        .AddDefaultTokenProviders();

    // srvc.AddAuthentication(options =>
    // {
    //   options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    //   options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    // })
    // .AddJwtBearer(options =>
    // {
    //   options.TokenValidationParameters = new TokenValidationParameters
    //   {
    //     ValidateIssuer = true,
    //     ValidateAudience = true,
    //     ValidateLifetime = true,
    //     ValidateIssuerSigningKey = true,
    //     ValidIssuer = builder.Configuration["Jwt:Issuer"],
    //     ValidAudience = builder.Configuration["Jwt:Audience"],
    //     IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    //   };
    // });

    srvc.AddAuthorization();
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    ConfigureCrossCuttingConcern(app, env);
    // app.UseHttpsRedirection();

    app.UseRouting();

    app.UseEndpoints(endpoints =>
    {
      endpoints.MapControllers();
    });
    app.UseAuthentication();
    app.UseAuthorization();
    // app.Use(async (context, next) =>
    // {
    //   if (context.Request.Path == "/")
    //   {
    //     context.Response.Redirect("/swagger/index.html");
    //     return;
    //   }
    //   await next();
    // });

  }
  public void ConfigureCrossCuttingConcern(IApplicationBuilder app, IWebHostEnvironment env)
  {
    // env.IsDevelopment() || env.IsDev();
    if (true)
    {
      app.UseDeveloperExceptionPage();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Platform Service");
        c.RoutePrefix = "swagger"; // string.Empty; // Optional: Serve Swagger UI at the app's root
      });
    }
    if (!env.IsDevelopment())
    {
      // app.Seed();
    }
  }
}