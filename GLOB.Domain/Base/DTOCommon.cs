using System.ComponentModel.DataAnnotations;
using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;
public class DtoCreate
{
  [Required]
  [StringLength(maximumLength: 50, ErrorMessage = "Max Characters 50 Allowed")]
  public string Name { get; set; } = "";
  [StringLength(maximumLength: 100, ErrorMessage = "Max Characters 100 Allowed")]
  public string? Desc { get; set; }

}
public class DtoUpdate : DtoCreate
{
  public Status? Status { get; set; } // = Status.None;

}
public class DtoRead : DtoUpdate
{
  public int? Id { get; set; } = null;
  public DateTimeOffset? CreatedAt { get; set; }
  public DateTimeOffset? UpdatedAt { get; set; }

}


public class DtoSelect<TKey>
{
  public TKey Id { get; set; }
  public string Name { get; set; } = "";
  public bool IsSelected = false;
  public Status? Status { get; set; }
}
public class DtoSelect : DtoSelect<int>
{
}
public class DtoSearch
{
  public string? Name { get; set; }
  public Status? Status { get; set; }
  public string? Desc { get; set; }
  public DateTimeOffset? DateFrom { get; set; }
  public DateTimeOffset? DateTo { get; set; }
}