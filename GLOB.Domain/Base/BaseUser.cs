using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace GLOB.Domain.Base;
public abstract class BaseUser : BaseEntity
{
  // Name = Title
  public required string Phone { get; set; }
  public required string Email { get; set; }
  // public GENDER? Gender { get; set; }
  // [NotMapped]
  // public string Genderz
  // {
  //   get
  //   {
  //     return Gender.ToString().ToEnumStr1();
  //   }
  // }
  public string? UrlImg { get; set; }
  [NotMapped]
  public IFormFile? ImageFile { get; set; } = null;
  public required string Password { get; set; }
  [NotMapped]
  public string? ConfirmPassword { get; set; }
  public string? ForgotPassword { get; set; }
  public bool IsVerified { get; set; } = false;
  public bool IsEmailVerified { get; set; } = false;
}
public class UserType
{
  private UserType(string value) { Value = value; }

  public string Value { get; private set; }

  public static UserType ADMIN { get { return new UserType("USER_ADMIN"); } }
  public static UserType STANDARD { get { return new UserType("USER_STANDARD"); } }
  public static UserType BUSINESS { get { return new UserType("USER_BUSINESS"); } }
  public static UserType CREATOR { get { return new UserType("USER_CREATOR"); } }
  public static UserType AGENT { get { return new UserType("USER_AGENT"); } }

  public override string ToString()
  {
    return Value;
  }
}
