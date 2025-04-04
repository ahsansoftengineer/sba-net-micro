using GLOB.API.Mapper;
using GLOB.Domain.Auth;
using GLOB.Domain.Hierarchy;

namespace SBA.Projectz.Mapper;
public partial class MapProj : MapBase
{
  public MapProj() : base()
  {
  }
  public override void MapAll() 
  {
    base.MapAll();
    CreateMap<InfraUser, InfraUserDto>();
    // CreateMapAll<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
  }
}