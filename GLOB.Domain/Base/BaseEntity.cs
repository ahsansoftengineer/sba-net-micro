using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;
public static class Defaultz
{
  // TODO: We need to have a way of setting Default Date for Migration on 
  public static Status? Status { get; } = Enums.Status.None;
  public static  DateTimeOffset Date { get; } = DateTimeOffset.Parse("2025-02-10T00:00:00");
  public static string Guidz() => Guid.NewGuid().ToString();
}
public abstract class EntityAlpha : IEntityAlpha, IEntityStatus
{
    [Column(Order = 1)]
    [Key]
    public int Id { get; set; }
    [Column(Order = 2)]
    public Status? Status { get; set; } = Defaultz.Status;
    [Column(Order = 3)] // required
    public string Title { get; set; }
}
public abstract class EntityBeta : EntityAlpha, IEntityBeta
{
  [Column("Created_At")]
  public DateTimeOffset? CreatedAt { get; set; } = Defaultz.Date;
  [Column("Updated_At")]
  public DateTimeOffset? UpdatedAt { get; set; } = Defaultz.Date;
}

public abstract class EntityBase : EntityBeta, IEntityBase
{

  [Column(Order = 4)]
  public string? Desc { get; set; }
  [NotMapped]
  public bool? IsSelected { get; set; } = false;
}