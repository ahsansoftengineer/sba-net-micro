using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;
public abstract class AlphaEntity
{
  [Column(Order = 1)]
  [Key]
  public int? Id { get; set; }
  [Column(Order = 2)]
  public Status? Status { get; set; }  = Enums.Status.None;
}
public abstract class BetaEntity : AlphaEntity
{
  [Column("Created_At")]
  public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Parse("2025-02-10T00:00:00");
  [Column("Updated_At")]
  public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.Parse("2025-02-10T00:00:00");
}

public abstract class BaseEntity : BetaEntity, IBaseEntity
{
  [Column(Order = 3)] // required
  public string Title { get; set; }

  [Column(Order = 4)]
  public string? Desc { get; set; }
  [NotMapped]
  public bool? IsSelected { get; set; } = false;
}

public interface IBaseEntity
{
    int? Id { get; set; }
    DateTimeOffset? CreatedAt { get; set; }
    DateTimeOffset? UpdatedAt { get; set; }
    string Title { get; set; }
    Status? Status { get; set; }
    string? Desc { get; set; }
    bool? IsSelected { get; set; }
}
