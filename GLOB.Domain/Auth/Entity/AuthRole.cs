using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class Role : IdentityRole
{
    public Permission Permissions { get; set; }
    public Status? Status { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public Role(string name, Permission permissions)
    {
        Name = name;
        Permissions = permissions;
    }
    public bool HasPermission(Permission permission)
    {
        return (Permissions & permission) == permission;
    }
}
