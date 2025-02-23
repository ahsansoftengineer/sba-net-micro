using GLOB.Domain.Projectz;

namespace SBA.Projectz.Mapper;
public partial class MapProj 
{
  public override void MapCommon() 
  {
    base.MapCommon();
    CreateMapCommon<TestProj>();
  }
}