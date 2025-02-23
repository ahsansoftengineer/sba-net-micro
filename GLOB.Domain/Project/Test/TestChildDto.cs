using GLOB.Domain.Base;

namespace GLOB.Domain.DTOs;
public class TestChildDtoCreate : DtoCreate
{
  public int TestParentId { get; set; }
}
public class TestChildDto : DtoRead
{
  public int TestParentId { get; set; }
  public DtoSelect? TestParent { get; set; }
}
public class TestChildDtoSearch : DtoSearch
{
  public int? TestParentId { get; set; }
}