using GLOB.API.Mapper;
using GLOB.Domain.Hierarchy;

namespace SBA.Projectz.Mapper;
public partial class ProjectzMapper : API_Base_Mapper
{
  public ProjectzMapper() : base()
  {
  }
  public override void MapAll() 
  {
    base.MapAll();
    CreateMapAll<Systemz, SystemzDtoCreate, SystemzDtoRead, SystemzDtoSearch>();
    CreateMapAll<LE, LEDtoCreate, LEDtoRead, LEDtoSearch>();
    CreateMapAll<OU, OUDtoCreate, OUDtoRead, OUDtoSearch>();
    CreateMapAll<SU, SUDtoCreate, SUDtoRead, SUDtoSearch>();
    CreateMapAll<City, CityDtoCreate, CityDtoRead, CityDtoSearch>();
  }
}