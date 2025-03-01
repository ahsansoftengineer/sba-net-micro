using GLOB.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using GLOB.Infra.UOW;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Options;
using GLOB.Infra.Auth;

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
    srvc.AddIdentity<AuthUser, AuthRole>()
        .AddEntityFrameworkStores<TContext>()
        .AddDefaultTokenProviders();
        // .ConfigureOptions<IdentityOptionsSetup>();

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
          ValidateIssuer = true,
          ValidIssuer = jwtSettings.Issuer,
          ValidateAudience = true,
          ValidAudience = jwtSettings.Audience,
          ValidateLifetime = true,
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
//   "ConnectionStrings": {
//     "SqlConnection": "Server=YOUR_SERVER;Database=YOUR_DATABASE;User Id=YOUR_USER;Password=YOUR_PASSWORD;Trusted_Connection=False;MultipleActiveResultSets=true;"
//   },

//  "JwtSettings": {
//     "SecretKey": "YourSuperStrongSecretKey_ReplaceThis", 
//     "Issuer": "YourApp",
//     "Audience": "YourClientApp",
//     "ExpireMinutes": 60
//   },

//   "Identity": {
//     "RequireUniqueEmail": true,
//     "Password": {
//       "RequireDigit": true,
//       "RequiredLength": 8,
//       "RequireNonAlphanumeric": true,
//       "RequireUppercase": true,
//       "RequireLowercase": true
//     },
//     "Lockout": {
//       "MaxFailedAccessAttempts": 5,
//       "DefaultLockoutTimeSpanInMinutes": 10
//     },
//     "User": {
//       "AllowedUserNameCharacters": "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+"
//     }
//   },
