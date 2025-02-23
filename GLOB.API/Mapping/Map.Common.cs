using GLOB.Domain.Hierarchy;

namespace GLOB.API.Mapper;
public class MapCommon : MapBase
{
  public MapCommon() : base()
  {
    CreateMapCommon<TestInfra>();
  }
}