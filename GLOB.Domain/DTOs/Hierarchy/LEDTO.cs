using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class LEDtoCreate : BaseDtoCreate
{
  public int BGId { get; set; }
}
public class LEDto : BaseDtoFull
{
  public int BGId { get; set; }
  public BaseDtoSelect? BG { get; set; }
}
public class LEDtoSearch : BaseDtoSearchFull
{
  public int? BGId { get; set; }
}