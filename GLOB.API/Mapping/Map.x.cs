using GLOB.Domain.Projectz;

namespace GLOB.API.Mapper;
public partial class MapBase 
{
  public virtual void MapCommon()
  {
    CreateMap_Entity_DefaultDtos<TestInfra>();
    // CreateMapCommon<IEntityBeta>();
    // CreateMapCommon<IEntityBase>();
  }
}