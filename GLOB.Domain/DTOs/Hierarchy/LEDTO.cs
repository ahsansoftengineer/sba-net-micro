using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class LEDtoCreate : DtoCreate
{
  public int BGId { get; set; }
}
public class LEDto : DtoRead
{
  public int BGId { get; set; }
  public DtoSelect? BG { get; set; }
}
public class LEDtoSearch : BaseDtoSearchFull
{
  public int? BGId { get; set; }
}