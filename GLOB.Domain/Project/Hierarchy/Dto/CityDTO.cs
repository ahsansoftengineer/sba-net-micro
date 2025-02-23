using GLOB.Domain.Base;

namespace GLOB.Domain.Hierarchy;
public class CityDto : DtoRead
{
  public int StateId { get; set; }
  public DtoSelect? State { get; set; }
}
public class CityDtoCreate : DtoCreate
{
  public int StateId { get; set; }
}
public class CityDtoSearch : DtoSearch
{
  public int? StateId { get; set; }
}