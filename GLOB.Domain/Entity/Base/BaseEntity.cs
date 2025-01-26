using GLOB.Domain.Enums;

namespace GLOB.Domain.Entity;
public abstract class AlphaEntity
{
  public int? Id { get; set; }
}
public abstract class BaseEntity : AlphaEntity
{
  public string? Title { get; set; }
  public string? Desc { get; set; }
  public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
  public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
}
public abstract class BaseStatusEntity : BaseEntity
{
  //[NotMapped]
  public Status? Status { get; set; } // = Status.None;
}