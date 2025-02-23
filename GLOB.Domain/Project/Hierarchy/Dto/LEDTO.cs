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
public class LEDtoSearch : DtoSearch
{
  public int? BGId { get; set; }
}