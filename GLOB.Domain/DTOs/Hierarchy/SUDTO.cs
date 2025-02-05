using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class SUDtoCreate : BaseDtoCreate
{
  public int OUId { get; set; }
}

public class SUDto : BaseDtoFull
{
  public int OUId { get; set; }
  public BaseDtoRelation? OU { get; set; }
}
public class SUDtoSearch : BaseDtoSearchFull
{
  public int? OUId { get; set; }
}