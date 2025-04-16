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
public class DtoRead : DtoRead<int>
{
}
public class DtoRead<TKey> : DtoUpdate
{
  public TKey Id { get; set; }
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

public interface IDtoSearch
{
    string? Name { get; set; }
    Status? Status { get; set; }
    string? Desc { get; set; }
    DateTimeOffset? DateFrom { get; set; }
    DateTimeOffset? DateTo { get; set; }
}

public class DtoSearch : IDtoSearch
{
    public string? Name { get; set; }
    public Status? Status { get; set; }
    public string? Desc { get; set; }
    public DateTimeOffset? DateFrom { get; set; }
    public DateTimeOffset? DateTo { get; set; }
}