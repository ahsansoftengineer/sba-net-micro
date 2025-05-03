using GLOB.API.Config.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.API.Config.DI;
public static partial class API_DI_Common
{
  public static void Config_Authentication_JWT(this IServiceCollection srvc, IConfiguration config)
  {
    
    var jwtSettings = config.Get<IOptions<JwtSettings>>().Value;

    // srvc.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    srvc.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
      options.SaveToken = true;
      options.RequireHttpsMetadata = false;
      options.TokenValidationParameters = new TokenValidationParameters()
      {
        ValidIssuer = jwtSettings.Issuer,
        ValidAudience = jwtSettings.Audience,

        ValidateIssuer = jwtSettings.ValidateIssuer,
        ValidateLifetime = jwtSettings.ValidateLifetime,
        ValidateAudience = jwtSettings.ValidateAudience,

        IssuerSigningKey = jwtSettings.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = jwtSettings.ValidateIssuerSigningKey,
      };
    });
  }
}