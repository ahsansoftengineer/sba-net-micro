using System.ComponentModel;

namespace GLOB.Infra.Model.Base;

public class DtoRequestGet
{
  [DefaultValue(null)]
  public List<string>? Includes { get; set; }
}

public class DtoRequestStatus
{
  public Status Status { get; set; } = Status.None;
}

public class DtoRequestGetByIds : DtoRequestGetByIds<int> { }
public class DtoRequestGetByIds<TKey>
{
  public List<TKey>? Ids { get; set; } = null;
}