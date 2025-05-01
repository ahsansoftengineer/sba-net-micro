using System.ComponentModel.DataAnnotations;

namespace GLOB.Domain.Auth;

public class RefreshToken
{
  [Key]
  public int Id { get; set; }  // Primary key

  public string Token { get; set; }
  public string JwtId { get; set; } // to validate against the original JWT
  public bool IsRevoked { get; set; }
  public bool IsUsed { get; set; }
  public string CreatedByIp { get; set; }
  public DateTimeOffset CreatedAt { get; set; }
  public DateTimeOffset ExpiresAt { get; set; }

  public string InfraUserId { get; set; }
  // Relationships
  public InfraUser InfraUser { get; set; }
}

public class RefreshTokenRequest
{
  public string AccessToken { get; set; }
  public string RefreshToken { get; set; }
}
