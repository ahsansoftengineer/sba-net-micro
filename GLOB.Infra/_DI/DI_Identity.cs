using Microsoft.AspNetCore.Identity;
using GLOB.Infra.UOW_Projectz;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using GLOB.Infra.Data.Auth;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace GLOB.Infra.DI;
public static partial class DI_Infra
{
  public static void Config_DB_Identity<TContext, TIUOW, TUOW>(this IServiceCollection srvc, IConfiguration config)
    where TContext : DBCntxtIdentity
    where TIUOW : class, IUOW_Infra
    where TUOW : UOW_Infra, TIUOW
  {
    // Option Pattern
    srvc.Configure<JwtSettings>(config.GetSection(JwtSettings.SectionName));
    srvc.Configure<IdentitySettings>(config.GetSection("Identity"));

    // Configure Database
    srvc.Config_DB_SQL<TContext, TIUOW, TUOW>(config);

    // Configure Identity with roles
    // srvc.AddIdentity<InfraUser, InfraRole>()
    srvc.AddIdentity<InfraUser, InfraRole>()
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

}

// "ConnectionStrings": {
//   "SqlConnection": "Server=127.0.0.1,1430;Initial Catalog=SBA_Auth;User ID=sa;Password=P@55w0rd!123;TrustServerCertificate=true;"
// },

