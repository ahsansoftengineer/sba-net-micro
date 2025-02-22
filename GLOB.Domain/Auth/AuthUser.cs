using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class AuthUser : IdentityUser, IBaseEntity
{

    public string Title { get; set; }
    public UserTypeEnum UserType { get; set; }
    public ICollection<EntityPermission> EntityPermissions {get; set;} = new List<EntityPermission>();

    public int OrgId { get; set; }
    public int SystemzId { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public Status? Status { get; set; }
    public string? Desc { get; set; }
    public bool? IsSelected { get; set; }
    int? IBaseEntity.Id { get; set; }
}
