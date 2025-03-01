using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.Infra.Auth;
public class JwtSettings
{
  public string SecretKey { get; set; }
  public string Issuer { get; set; }
  public string Audience { get; set; }
  public int ExpireMinutes { get; set; }

  public SymmetricSecurityKey GetSymmetricSecurityKey()
  {
    return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey));
  }
}
public class IdentitySettings
{
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
  public int MaxFailedAccessAttempts { get; set; }
  public int DefaultLockoutTimeSpanInMinutes { get; set; }
}