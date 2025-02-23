using GLOB.Domain.Hierarchy;
using GLOB.Domain.Projectz;

namespace SBA.Projectz.Mapper;
public partial class MapProj 
{
  public override void MapCommon() 
  {
    base.MapCommon();
    CreateMapCommon<TestProj>();
    CreateMapCommon<Org>();
    CreateMapCommon<BG>();
    CreateMapCommon<Bank>();
    CreateMapCommon<Brand>();
    CreateMapCommon<Industry>();
    CreateMapCommon<Profession>();
    CreateMapCommon<State>();
  }
}