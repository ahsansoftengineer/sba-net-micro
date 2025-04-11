using GLOB.Domain.Hierarchy;
using GLOB.Domain.Projectz;
using GLOB.Hierarchy.Global;

namespace SBA.Projectz.Mapper;
public partial class ProjectzMapper 
{
  public override void MapCommon() 
  {
    base.MapCommon();
    CreateMap_Entity_DefaultDtos<GlobalLookupzBase>();
    CreateMap_Entity_DefaultDtos<ProjectzEntityTest>();

    CreateMap_Entity_DefaultDtos<Org>();
    CreateMap_Entity_DefaultDtos<BG>();
    CreateMap_Entity_DefaultDtos<Bank>();
    CreateMap_Entity_DefaultDtos<Brand>();
    CreateMap_Entity_DefaultDtos<Industry>();
    CreateMap_Entity_DefaultDtos<Profession>();
    CreateMap_Entity_DefaultDtos<State>();
  }
}