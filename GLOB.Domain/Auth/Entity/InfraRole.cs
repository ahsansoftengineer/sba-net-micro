using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Enums;
using GLOB.Domain.Enumz;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class InfraRole : IdentityRole<string>
{
    // public Permission Permissions { get; set; }
    public Status? Status { get; set; }
    public DateTimeOffset? CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    [NotMapped]
    public string Title { get; set; /*{ Name = value; }*/ }
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
