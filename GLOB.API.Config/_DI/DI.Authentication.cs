using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.API.Config.DI;
public static partial class DI_API_Config
{
  public static AuthenticationBuilder Add_Authentication_JWT(this IServiceCollection srvc, IConfiguration config)
  {
    IHostEnvironment env = srvc.BuildServiceProvider().GetRequiredService<IHostEnvironment>();

    var jwt = new JwtSettings();
    config.GetSection(JwtSettings.SectionName).Bind(jwt);

    return srvc.AddAuthentication(options =>
    {
      options.Config_AuthenticationOptions();
    })
    .AddJwtBearer(options =>
    {
      options.SaveToken = true;
      options.RequireHttpsMetadata = env.IsProduction();
      options.TokenValidationParameters = new TokenValidationParameters()
      {
        ValidIssuer = jwt.Issuer,
        ValidAudience = jwt.Audience,
        ValidateIssuer = jwt.ValidateIssuer,
        ValidateLifetime = jwt.ValidateLifetime,
        ValidateAudience = jwt.ValidateAudience,
        ValidateIssuerSigningKey = jwt.ValidateIssuerSigningKey,
        IssuerSigningKey = jwt.GetSymmetricSecurityKey(),
        ClockSkew = TimeSpan.Zero, // Optional: Adjust clock skew as needed

        // JWT Roles Config
        // RoleClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
        // NameClaimType = ClaimTypes.NameIdentifier
      };
      options.Events = new JwtBearerEvents
      {
        OnChallenge = context =>
        {
          context.HandleResponse(); // Suppress default 302 redirect
          context.Response.StatusCode = StatusCodes.Status401Unauthorized;
          context.Response.ContentType = "application/json";
          return context.Response.WriteAsync("{\"error\": \"Unauthorized\"}");
        },
        OnTokenValidated = async context =>
        {
          // var jti = context.Principal.FindFirst(JwtRegisteredClaimNames.Jti)?.Value;
          // var db = context.HttpContext.RequestServices.GetRequiredService<DBCtxProjectz>();
          // var isRevoked = await db.RevokedTokens.AnyAsync(t => t.Jti == jti);

          // if (isRevoked)
          // {
          //   context.Fail("Access token has been revoked.");
          // }
        }
      };
    })
    .AddCookie(JwtSettings.Scheme, options =>
    {
      options.LoginPath = jwt.LoginPath; // Specify your login path if required
      options.Cookie.Name = jwt.CookieName;
      options.AccessDeniedPath = jwt.AccessDeniedPath;
      options.ExpireTimeSpan = TimeSpan.FromMinutes(jwt.AccessTokenExpiryMinutes);
      options.SlidingExpiration = true; // cookie’s lifetime will renew on every request
    });
   
  }

  public static void Config_Post_Authentication_JWT_Option(this IServiceCollection srvc)
  {
    srvc.PostConfigure<AuthenticationOptions>(options =>
    {
      options.Config_AuthenticationOptions();
    });
  }

  private static void Config_AuthenticationOptions(this AuthenticationOptions options)
  {
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
  }
}









public class JwtSettings
{

  public static string SectionName = "JwtSettings";
  public string SecretKey { get; set; } //"YourSuperStrongSecretKey_ReplaceThis"
  public string Issuer { get; set; } // "https://localhost:5802/"
  public string Audience { get; set; } // "https://localhost:5802/"
  public int AccessTokenExpiryMinutes { get; set; } //60 -> 15
  public int AccessTokenExpiryHour { get; set; } //1
  public int RefreshTokenExpiryDays { get; set; } //7
  public bool ValidateIssuer { get; set; }// = true;
  public bool ValidateAudience { get; set; }// = true;
  public bool ValidateLifetime { get; set; }// = true;
  public bool ValidateIssuerSigningKey { get; set; }// = true;

  // Cookie
  public static string Scheme = "AuthorizationCookieScheme";
  public string LoginPath { get; set; }
  public string CookieName { get; set; }
  public string AccessDeniedPath { get; set; }
  public bool SlidingExpiration { get; set; }// = true;


  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
  }
}