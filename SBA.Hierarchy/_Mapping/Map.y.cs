using GLOB.API.Mapper;
using GLOB.Domain.Hierarchy;

namespace SBA.Projectz.Mapper;
public partial class ProjectzMapper : MapBase
{
  // public ProjectzMapper() : base()
  // {
  //   // MapAll();
  //   // MapCommon();
  // }
  public override void MapAll() 
  {
    base.MapAll();
    CreateMapAll<Systemz, LEDtoCreate, SystemzDtoCreate, SystemzDtoSearch, LEDtoRead>();
    CreateMapAll<LE, LEDtoCreate, LEDtoRead, LEDtoSearch>();
    CreateMapAll<OU, OUDtoCreate, OUDtoRead, OUDtoSearch>();
    CreateMapAll<SU, SUDtoCreate, SUDtoRead, SUDtoSearch>();
    CreateMapAll<City, CityDtoCreate, CityDtoRead, CityDtoSearch>();
  }
}