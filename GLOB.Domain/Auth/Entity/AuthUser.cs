using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class AuthUser : IdentityUser //, IBetaEntity
{
    // int IBetaEntity.Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    public Status? Status { get; set; }
    public string Title { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    // Maybe below code need to shift into their classes

    // public UserTypeEnum UserType { get; set; }
    // public ICollection<EntityPermission> EntityPermissions {get; set;} = new List<EntityPermission>();

    // public int OrgId { get; set; }
    // public int SystemzId { get; set; }
}
