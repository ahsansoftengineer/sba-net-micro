using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class CityDto : BaseDtoFull
{
  public int StateId { get; set; }
  public BaseDtoRelation? State { get; set; }
}
public class CityDtoCreate : BaseDtoCreate
{
  public int StateId { get; set; }
}
public class CityDtoSearch : BaseDtoSearchFull
{
  public int? StateId { get; set; }
}