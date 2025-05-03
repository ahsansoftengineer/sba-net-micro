using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.API.Config.Model;
public class JwtSettings
{
  public static string SectionName = "JwtSettings";
  public string SecretKey { get; set; } //"YourSuperStrongSecretKey_ReplaceThis"
  public string Issuer { get; set; } // "https://localhost:5802/"
  public string Audience { get; set; } // "https://localhost:5802/"
  public int ExpireMinutes { get; set; } //6000
  public bool ValidateIssuer { get; set; } = false;
  public bool ValidateAudience { get; set; } = false;
  public bool ValidateLifetime { get; set; } = false;
  public bool ValidateIssuerSigningKey { get; set; } = false;

  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
  }
}