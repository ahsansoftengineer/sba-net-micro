using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace GLOB.Domain.Base;
public abstract class BaseUser : BaseEntity, IBaseEntity
{
  public string? UrlImg { get; set; }
  [NotMapped]
  public IFormFile? ImageFile { get; set; } = null;
  public string? ForgotPassword { get; set; }
  public bool IsVerified { get; set; } = false;
}