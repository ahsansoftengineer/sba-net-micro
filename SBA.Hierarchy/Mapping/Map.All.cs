using GLOB.API;
using GLOB.Domain.Hierarchy;

namespace SBA.Proj.Mapper;
public class MapAllProj : MapAll
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