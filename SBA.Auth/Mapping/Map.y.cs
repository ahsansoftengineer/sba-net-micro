using GLOB.API.Mapper;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;

namespace SBA.Projectz.Mapper;
public partial class MapProj : MapBase
{
  public MapProj() : base()
  {
  }
  public override void MapAll() 
  {
    base.MapAll();
    CreateMapAll<InfraUser, InfraUserDtoCreate, InfraUserDtoUpdate, InfraUserDtoRead, InfraUserDtoSearch, DtoSelect>();
    
    // CreateMapAll<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
  }
}