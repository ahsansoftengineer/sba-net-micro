using GLOB.Infra.Model.Base;

namespace GLOB.API.Mapper;
public partial class API_Base_Mapper 
{
  public virtual void MapCommon()
  {
    CreateMap_Entity_DefaultDtos<ProjectzLookupBase>();
  }
}