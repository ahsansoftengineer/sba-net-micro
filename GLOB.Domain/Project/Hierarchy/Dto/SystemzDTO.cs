using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class SystemzDto : DtoRead
{
  public int OrgId { get; set; }
  public DtoSelect? Org { get; set; }
}
public class SystemzDtoCreate : DtoCreate
{
  public int OrgId { get; set; }
}
public class SystemzDtoSearch : DtoSearch
{
  public int? OrgId { get; set; }
}