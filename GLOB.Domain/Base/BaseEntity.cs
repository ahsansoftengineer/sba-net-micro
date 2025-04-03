using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;

public abstract class EntityAlpha : IEntityAlpha, IEntityStatus
{
    [Column(Order = 1)]
    [Key]
    public int Id { get; set; }
    [Column(Order = 2)]
    public Status? Status { get; set; } = Enums.Status.None;
    [Column(Order = 3)] // required
    public string Title { get; set; }
}
public abstract class EntityBeta : EntityAlpha, IEntityBeta
{
  [Column("Created_At")]
  public DateTimeOffset? CreatedAt { get; set; } = DateTimeOffset.Parse("2025-02-10T00:00:00");
  [Column("Updated_At")]
  public DateTimeOffset? UpdatedAt { get; set; } = DateTimeOffset.Parse("2025-02-10T00:00:00");
}

public abstract class EntityBase : EntityBeta, IEntityBase
{

  [Column(Order = 4)]
  public string? Desc { get; set; }
  [NotMapped]
  public bool? IsSelected { get; set; } = false;
}