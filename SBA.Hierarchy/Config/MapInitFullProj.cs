using GLOB.API;
using GLOB.Domain.DTOs;
using GLOB.Domain.Entity;

namespace SBA.Hierarchy.Config;
public class MapInitFullProj : MapInitFull
{
  public MapInitFullProj() : base()
  {
    CreateMapAll<Systemz, SystemzDto, SystemzDtoCreate, SystemzDtoSearch>();
    CreateMapAll<LE, LEDto, LEDtoCreate, LEDtoSearch>();
    CreateMapAll<OU, OUDto, OUDtoCreate, OUDtoSearch>();
    CreateMapAll<SU, SUDto, SUDtoCreate, SUDtoSearch>();
    CreateMapAll<City, CityDto, CityDtoCreate, CityDtoSearch>();
  }
}