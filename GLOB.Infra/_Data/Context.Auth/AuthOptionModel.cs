using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.Infra.Data.Auth;
public class JwtSettings
{
  public static string SectionName = "JwtSettings";
  public string SecretKey { get; set; } //"YourSuperStrongSecretKey_ReplaceThis"
  public string Issuer { get; set; } // "https://localhost:5802/"
  public string Audience { get; set; } // "https://localhost:5802/"
  public int ExpireMinutes { get; set; } //6000

  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
  }
}
public class IdentitySettings
{
  public static string SectionName = "IdentitySettings";
  public bool RequireUniqueEmail { get; set; }
  public PasswordSettings Password { get; set; }
  public LockoutSettings Lockout { get; set; }
  public string AllowedUserNameCharacters { get; set; }
}

public class PasswordSettings
{
  public bool RequireDigit { get; set; }
  public int RequiredLength { get; set; }
  public bool RequireNonAlphanumeric { get; set; }
  public bool RequireUppercase { get; set; }
  public bool RequireLowercase { get; set; }
}

public class LockoutSettings
{
  public int MaxFailAttempts { get; set; }
  public int LockoutMinutes { get; set; }
}