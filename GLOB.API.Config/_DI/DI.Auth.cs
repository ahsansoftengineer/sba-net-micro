using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.API.Config.DI;
public static partial class DI_API_Config
{
  public static void Config_Authentication_JWT(this IServiceCollection srvc, IConfiguration config)
  {
    
    var jwt = new JwtSettings();
    config.GetSection("JwtSettings").Bind(jwt);

    // srvc.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
    srvc.AddAuthentication(options =>
    {
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      // options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
      options.SaveToken = true;
      options.RequireHttpsMetadata = false;
      options.TokenValidationParameters = new TokenValidationParameters()
      {
        // ValidIssuer = jwt.Issuer,
        // ValidAudience = jwt.Audience,

        ValidateIssuer = jwt.ValidateIssuer,
        ValidateLifetime = jwt.ValidateLifetime,
        ValidateAudience = jwt.ValidateAudience,

        IssuerSigningKey = jwt.GetSymmetricSecurityKey(),
        ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
        ClockSkew = TimeSpan.Zero // Optional: Adjust clock skew as needed
      };
      options.Events = new JwtBearerEvents
      {
          OnChallenge = context =>
          {
              context.HandleResponse(); // Suppress default 302 redirect
              context.Response.StatusCode = StatusCodes.Status401Unauthorized;
              context.Response.ContentType = "application/json";
              return context.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
          }
      };
      // options.Events = new JwtBearerEvents
      // {
      //   OnTokenValidated = async context =>
      //   {
      //     var jti = context.Principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
      //     var db = context.HttpContext.RequestServices.GetRequiredService<DBCtxProjectz>();
      //     var isRevoked = await db.RevokedTokens.AnyAsync(t => t.Jti == jti);

      //     if (isRevoked)
      //     {
      //         context.Fail("Access token has been revoked.");
      //     }
      //   }
      // };
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