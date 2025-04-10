using GLOB.Domain.Projectz;

namespace SBA.Projectz.Mapper;
public partial class ProjectzMapper 
{
  public override void MapCommon() 
  {
    base.MapCommon();
    CreateMap_Entity_DefaultDtos<ProjectzEntityTest>();
  }
}