using GLOB.Domain.Base;
using GLOB.Domain.Contants;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class InfraRole : IdentityRole<string>, IEntityBeta,  IEntityStatus, IEntityAlpha<string>
{
  // public Permission Permissions { get; set; }
  public override string Name { get; set; }
  public Status? Status { get; set; } = Constantz.Status;
  public DateTimeOffset? CreatedAt { get; set; } = Constantz.Date;
  public DateTimeOffset? UpdatedAt { get; set; } = Constantz.Date;
  public InfraRole(): base()
  {

  }
  public InfraRole(string name) : base(name)
  {
    // Permissions = permissions;
  }
  // public bool HasPermission(Permission permission)
  // {
  //   return (Permissions & permission) == permission;
  // }
}
public class AssignRoleToInfraUser 
{
  public string Email { get; set; }
  public string Role { get; set; }
  
}