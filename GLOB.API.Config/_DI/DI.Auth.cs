using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.API.Config.DI;
public static partial class API_DI_Common
{
  public static void Config_Authentication_JWT(this IServiceCollection srvc, IConfiguration config)
  {
    
    var jwt = config.Get<IOptions<JwtSettings>>().Value;

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
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,

        ValidateIssuer = jwt.ValidateIssuer,
        ValidateLifetime = jwt.ValidateLifetime,
        ValidateAudience = jwt.ValidateAudience,

        IssuerSigningKey = jwt.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
      };
    });
  }
}
public class JwtSettings
{
  public static string SectionName = "JwtSettings";
  public string SecretKey { get; set; } //"YourSuperStrongSecretKey_ReplaceThis"
  public string Issuer { get; set; } // "https://localhost:5802/"
  public string Audience { get; set; } // "https://localhost:5802/"
  public int AccessTokenExpiryMinutes { get; set; } //60
  public int AccessTokenExpiryHour { get; set; } //1
  public int RefreshTokenExpiryDays { get; set; } //7
  public bool ValidateIssuer { get; set; } = false;
  public bool ValidateAudience { get; set; } = false;
  public bool ValidateLifetime { get; set; } = false;
  public bool ValidateIssuerSigningKey { get; set; } = false;

  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
  }
}