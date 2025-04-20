using GLOB.Domain.Base;

namespace GLOB.Domain.Auth;
public class RefreshToken : EntityBeta, IEntityBeta, IEntityAlpha
{
    public string Token { get; set; }
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }
    public string CreatedByIp { get; set; }

    // Relationships
    public string InfraUserId { get; set; }
    public InfraUser InfraUser { get; set; }
}
