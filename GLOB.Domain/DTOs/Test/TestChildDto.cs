using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class TestChildDtoCreate : BaseDtoCreate
{
  public int TestParentId { get; set; }
}
public class TestChildDto : BaseDtoFull
{
  public int TestParentId { get; set; }
  public BaseDtoSelect? TestParent { get; set; }
}
public class TestChildDtoSearch : BaseDtoSearchFull
{
  public int? TestParentId { get; set; }
}