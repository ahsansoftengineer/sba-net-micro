using GLOB.Domain.Base;

namespace GLOB.API.Mapper;
public partial class API_Base_Mapper 
{
  public virtual void MapAll()
  {
    CreateMapAll<ProjectzLookupzz, ProjectzLookupzzDtoCreate, ProjectzLookupzzDtoSearch>();
  }
}