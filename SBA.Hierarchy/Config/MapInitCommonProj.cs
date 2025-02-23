using GLOB.API.Config;
using GLOB.Domain.Common;
using GLOB.Domain.Hierarchy;

namespace SBA.Hierarchy.Config;
public class MapInitCommonProj : MapInitCommon
{
  public MapInitCommonProj() : base()
  {
    CreateMapCommon<TestProj>();
    CreateMapCommon<Org>();
    CreateMapCommon<BG>();
    CreateMapCommon<Bank>();
    CreateMapCommon<Brand>();
    CreateMapCommon<Industry>();
    CreateMapCommon<Profession>();
    CreateMapCommon<State>();
    // CreateMapPagedList<Org, DtoRead>();
  }
}