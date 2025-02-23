using GLOB.API.Mapper;
using GLOB.Domain.Hierarchy;

namespace SBA.Projectz.Mapper;
public partial class MapProj : MapBase
{
  public MapProj() : base()
  {
    // MapAll();
    // MapCommon();
  }
  public override void MapAll() 
  {
    base.MapAll();
    CreateMapAll<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
    CreateMapAll<LE, LEDto, LEDtoCreate, LEDtoSearch>();
    CreateMapAll<OU, OUDto, OUDtoCreate, OUDtoSearch>();
    CreateMapAll<SU, SUDto, SUDtoCreate, SUDtoSearch>();
    CreateMapAll<City, CityDto, CityDtoCreate, CityDtoSearch>();
  }
}