using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;

public interface IEntityAlpha<TKey>
{
  TKey Id { get; set; }
  string Name { get; set; }
}

public interface IEntityAlpha : IEntityAlpha<int>
{
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
