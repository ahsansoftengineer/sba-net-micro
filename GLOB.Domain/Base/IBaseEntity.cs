using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;

public interface IEntityAlpha
{
    int Id { get; set; }
    string Title { get; set; }
}
public interface IEntityStatus
{
    Status? Status { get; set; }
}
public interface IEntityBeta
{
  DateTimeOffset? CreatedAt { get; set; }
  DateTimeOffset? UpdatedAt { get; set; }
}

public interface IEntityBase
{
  string? Desc { get; set; }
  bool? IsSelected { get; set; }
}
