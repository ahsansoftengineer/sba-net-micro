using GLOB.Domain.Base;
using GLOB.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace GLOB.Domain.Auth;
public class InfraUser : IdentityUser<string>, IEntityBeta, IEntityStatus, IEntityAlpha<string>
{
  public string Name { get; set; }
  public Status? Status { get; set; } = Defaultz.Status;
  public DateTimeOffset? CreatedAt { get; set; } = Defaultz.Date;
  public DateTimeOffset? UpdatedAt { get; set; } = Defaultz.Date;

  // Maybe below code need to shift into their classes

  // public UserTypeEnum UserType { get; set; }
  // public ICollection<EntityPermission> EntityPermissions {get; set;} = new List<EntityPermission>();

  // public int OrgId { get; set; }
  // public int SystemzId { get; set; }
}


public class InfraUserDtoCreate : InfraUserDtoUpdate
{
  public required string UserName { get; set; }
  public required string Password { get; set; }
  public required string ConfirmPassword { get; set; }
}

public class InfraUserDtoUpdate
{
  public required string PhoneNumber { get; set; }
  public required string Name { get; set; }
  public Status? Status { get; set; }
}


public class InfraUserDtoRead : DtoRead
{
  public string PhoneNumber { get; set; }
}


public class InfraUserDtoSearch: DtoSearch
{
  public string? EMAIL { get; set; }
}