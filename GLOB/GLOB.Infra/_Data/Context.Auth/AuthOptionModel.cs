namespace GLOB.Infra.Data.Auth;

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