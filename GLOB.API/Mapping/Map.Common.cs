using GLOB.Domain.Projectz;

namespace GLOB.API.Mapper;
public class MapCommon : MapBase
{
  public MapCommon() : base()
  {
    CreateMapCommon<TestInfra>();
  }
}