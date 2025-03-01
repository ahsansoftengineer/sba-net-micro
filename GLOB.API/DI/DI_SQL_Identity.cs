using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GLOB.Infra.UOW;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using GLOB.Infra.Context.Auth;

namespace GLOB.API.DI;
public static partial class DICommon
{
  public static void Config_DB_Identity<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config)
    where TContext : DBCntxtIdentity
    where TIUOW : class, IUnitOfWorkz
    where TUOW : UnitOfWorkz, TIUOW
  {
    srvc.Configure<JwtSettings>(config.GetSection("JwtSettings"));
    srvc.Configure<IdentitySettings>(config.GetSection("Identity"));

    // Configure Database
    srvc.Config_DB_SQL<TContext, TIUOW, TUOW>(config);

    // Configure Identity with roles
    srvc.AddIdentity<UserInfra, AuthRole>()
        .AddEntityFrameworkStores<TContext>()
        .AddDefaultTokenProviders();
    
    srvc.AddSingleton<IConfigureOptions<IdentityOptions>, AuthOptionSetup>();
    
    // srvc.Configure<IdentityOptions>(options =>
    // {
    //     // Customize Identity options here
    //     options.Password.RequireDigit = true;
    //     options.Password.RequiredLength = 5;
    //     options.Password.RequireNonAlphanumeric = false;
    // });


    // Configure Authentication
    
    srvc.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
      .AddJwtBearer(options =>
      {
        using var serviceProvider = srvc.BuildServiceProvider();
        var jwtSettings = serviceProvider.GetRequiredService<IOptions<JwtSettings>>().Value;

        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = jwtSettings.GetSymmetricSecurityKey(),
          ValidIssuer = jwtSettings.Issuer,
          ValidAudience = jwtSettings.Audience,
          ValidateIssuer = false, // Prod
          ValidateAudience = false, // Prod
          ValidateLifetime = false, // Prod
          ClockSkew = TimeSpan.Zero
        };
      });


    srvc.AddAuthorization();
  }

  public static void Config_DB_SQL<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config)
    where TContext : DbContext
    where TIUOW : class, IUnitOfWorkz
    where TUOW : UnitOfWorkz, TIUOW
  {
    string connStr = config.GetConnectionString("SqlConnection");
    
    srvc.AddDbContext<TContext>(opt =>
    {
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
}

// "ConnectionStrings": {
//   "SqlConnection": "Server=127.0.0.1,1430;Initial Catalog=SBA_Auth;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"
// },

