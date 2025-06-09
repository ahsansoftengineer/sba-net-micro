using GLOB.API.Mapper;
using GLOB.Domain.Model.Auth;
using GLOB.Infra.Model.Base;

namespace SBA.Projectz.Mapper;
public partial class ProjectzMapper : API_Base_Mapper
{
  public ProjectzMapper() : base()
  {
  }
  public override void MapCustom() 
  {
    base.MapCustom();
    CreateMapAll<InfraUser, InfraUserDtoCreate, InfraUserDtoUpdate, InfraUserDtoRead, InfraUserDtoSearch, DtoSelect>();
    
    // CreateMapAll<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
  }
}