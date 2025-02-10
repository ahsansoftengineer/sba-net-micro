using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;
public abstract class AlphaEntity
{
  [Column(Order = 0)]
  public int? Id { get; set; }
}
public abstract class BetaEntity : AlphaEntity
{

  [Column("Created_At")]
  public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Parse("2024-10-15T08:21:57");
  [Column("Updated_At")]
  public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.Parse("2024-10-15T08:21:57");
}

public abstract class BaseEntity : BetaEntity
{
  public string? Title { get; set; }
  public string? Desc { get; set; }
}
public abstract class BaseStatusEntity : BaseEntity
{
  //[NotMapped]
  public Status? Status { get; set; } // = Status.None;
}