using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class InfraRole : IdentityRole<string>, IEntityBeta,  IEntityStatus, IEntityAlpha<string>
{
  // public Permission Permissions { get; set; }
  public override string Name { get; set; }
  public Status? Status { get; set; } = Defaultz.Status;
  public DateTimeOffset? CreatedAt { get; set; } = Defaultz.Date;
  public DateTimeOffset? UpdatedAt { get; set; } = Defaultz.Date;
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
public class InfraRoleCreate : DtoCreate
{
  
}

public class InfraRoleUpdate : DtoUpdate
{
  
}

public class InfraRoleDtoSearch : DtoSearch
{

}
