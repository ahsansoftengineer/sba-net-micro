using GLOB.API.Mapper;
using GLOB.Domain.Hierarchy;

namespace SBA.Projectz.Mapper;
public class MapAllProj : MapCommonProj
{
  public MapAllProj() : base()
  {
    CreateMapAll<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
    CreateMapAll<LE, LEDto, LEDtoCreate, LEDtoSearch>();
    CreateMapAll<OU, OUDto, OUDtoCreate, OUDtoSearch>();
    CreateMapAll<SU, SUDto, SUDtoCreate, SUDtoSearch>();
    CreateMapAll<City, CityDto, CityDtoCreate, CityDtoSearch>();
  }
}