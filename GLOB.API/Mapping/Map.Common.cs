using GLOB.Domain.Entity;

namespace GLOB.API.Config;
public class MapInitCommon : MapInitBase
{
  public MapInitCommon() : base()
  {
    CreateMapCommon<TestInfra>();
  }
}