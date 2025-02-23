using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class SUDtoCreate : DtoCreate
{
  public int OUId { get; set; }
}

public class SUDto : DtoRead
{
  public int OUId { get; set; }
  public DtoSelect? OU { get; set; }
}
public class SUDtoSearch : DtoSearch
{
  public int? OUId { get; set; }
}