using GLOB.Domain.Enums;

namespace GLOB.Domain.Base;

public class ReqGet
{
  public List<string> Includes { get; set; } = ["TableName"];
}

public class ReqStatus
{
  public Status Status { get; set; }
}

public class ReqGetByIds : ReqGetByIds<int> { }
public class ReqGetByIds<TKey>
{
  public List<TKey> Ids { get; set; }
  public List<string> Includes { get; set; } = ["TableName"];
}