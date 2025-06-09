using GLOB.Infra.Model.Base;

namespace GLOB.API.Mapper;
public partial class API_Base_Mapper 
{
  public virtual void MapCustom()
  {
    CreateMapAll<ProjectzLookup, ProjectzLookupDtoCreate, ProjectzLookupDtoSearch>();
  }
}