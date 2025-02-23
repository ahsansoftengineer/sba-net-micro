using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class CityDto : DtoRead
{
  public int StateId { get; set; }
  public DtoSelect? State { get; set; }
}
public class CityDtoCreate : DtoCreate
{
  public int StateId { get; set; }
}
public class CityDtoSearch : BaseDtoSearchFull
{
  public int? StateId { get; set; }
}