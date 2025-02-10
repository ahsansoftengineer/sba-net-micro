using GLOB.API.Config;
using GLOB.Domain.Common;
using GLOB.Domain.Entity;

namespace SBA.Hierarchy.Config;
public class MapInitCommonProj : MapInitCommon
{
  public MapInitCommonProj() : base()
  {
      CreateMapCommon<TestProj>();
      CreateMapCommon<Org>();
      CreateMapPagedList<Org, CommonDto>();
      CreateMapCommon<BG>();
  }
}