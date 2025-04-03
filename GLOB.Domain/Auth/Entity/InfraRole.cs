using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class InfraRole : IdentityRole<string>, IEntityBeta
{
    // public Permission Permissions { get; set; }
    public Status? Status { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public InfraRole(): base()
    {

    }
    public InfraRole(string name) : base(name)
    {
        // Permissions = permissions;
    }
    // public bool HasPermission(Permission permission)
    // {
    //     return (Permissions & permission) == permission;
    // }
}
