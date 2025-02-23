using GLOB.Domain.Hierarchy;

namespace GLOB.API.Config;
public class MapInitCommon : MapInitBase
{
  public MapInitCommon() : base()
  {
    CreateMapCommon<TestInfra>();
  }
}