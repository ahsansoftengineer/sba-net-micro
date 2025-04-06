using GLOB.API.Mapper;
using GLOB.Domain.Auth;

namespace SBA.Projectz.Mapper;
public partial class MapProj : MapBase
{
  public MapProj() : base()
  {
  }
  public override void MapAll() 
  {
    base.MapAll();
    CreateMapAll<InfraUser, InfraUserDto, InfraUserDtoCreate, InfraUserDtoSearch>();
    
    // CreateMapAll<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
  }
}