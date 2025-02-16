using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;
public abstract class AlphaEntity
{
  [Column(Order = 1)]
  [Key]
  public int? Id { get; set; }
}
public abstract class BetaEntity : AlphaEntity
{

  [Column("Created_At")]
  public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Parse("2025-02-10T08:21:57");
  [Column("Updated_At")]
  public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.Parse("2025-02-10T08:21:57");
}

public abstract class BaseEntity : BetaEntity
{
  [Column(Order = 2)] // required
  public string Title { get; set; }
  [Column(Order = 3)]
  public bool? IsActive { get; set; } = false;
  [Column(Order = 4)]
  public bool? IsDeleted { get; set; } = false;
  [Column(Order = 5)]
  public string? Desc { get; set; }
  [NotMapped]
  public bool? IsSelected { get; set; } = false;
}
public abstract class BaseStatusEntity : BaseEntity
{
  //[NotMapped]
  public Status? Status { get; set; } // = Status.None;
}