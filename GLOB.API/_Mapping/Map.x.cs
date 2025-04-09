using GLOB.Domain.Projectz;

namespace GLOB.API.Mapper;
public partial class API_Base_Mapper 
{
  public virtual void MapCommon()
  {
    CreateMap_Entity_DefaultDtos<API_Infra_EntityTest>();
    // CreateMapCommon<IEntityBeta>();
    // CreateMapCommon<IEntityBase>();
  }
}