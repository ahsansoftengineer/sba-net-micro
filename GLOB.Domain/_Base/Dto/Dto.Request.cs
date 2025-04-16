using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;

public class DtoRequestGet
{
  public List<string> Includes { get; set; } = ["TableName"];
}

public class DtoRequestStatus
{
  public Status Status { get; set; }
}

public class DtoRequestGetByIds : DtoRequestGetByIds<int> { }
public class DtoRequestGetByIds<TKey>
{
  public List<TKey> Ids { get; set; }
  public List<string> Includes { get; set; } = ["TableName"];
}