using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class InfraUser : IdentityUser<string>, IEntityBeta
{
    public Status? Status { get; set; }
    public string Name { get; set; }
    public DateTimeOffset? CreatedAt { get; set; } = Defaultz.Date;
    public DateTimeOffset? UpdatedAt { get; set; } = Defaultz.Date;

    // Maybe below code need to shift into their classes

    // public UserTypeEnum UserType { get; set; }
    // public ICollection<EntityPermission> EntityPermissions {get; set;} = new List<EntityPermission>();

    // public int OrgId { get; set; }
    // public int SystemzId { get; set; }
}

public class InfraUserDto
{
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset UpdatedAt { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string UserName { get; set; }
}