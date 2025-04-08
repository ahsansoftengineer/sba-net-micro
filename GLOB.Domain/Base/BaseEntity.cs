using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Contants;
using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;

public abstract class EntityAlpha<TKey> : IEntityAlpha<TKey>, IEntityStatus
where TKey : IEquatable<TKey>
{
  [Column(Order = 1)]
  [Key]
  public TKey Id { get; set; }

  [Column(Order = 2)]
  public Status? Status { get; set; } = Constantz.Status;

  [Column(Order = 3)] // required
  public string Name { get; set; }
}

public abstract class EntityAlpha : EntityAlpha<int>, IEntityAlpha
{
}

public abstract class EntityBeta : EntityAlpha, IEntityBeta
{
  [Column("Created_At")]
  public DateTimeOffset? CreatedAt { get; set; } = Constantz.Date;

  [Column("Updated_At")]
  public DateTimeOffset? UpdatedAt { get; set; } = Constantz.Date;
}

public abstract class EntityBase : EntityBeta, IEntityBase
{

  [Column(Order = 4)]
  public string? Desc { get; set; }

  [NotMapped]
  public bool? IsSelected { get; set; } = false;
}