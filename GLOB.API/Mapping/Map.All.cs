using GLOB.Domain.Base;
using GLOB.Domain.Projectz;

namespace GLOB.API.Mapper;
public class MapAll : MapCommon
{
  public MapAll() : base()
  {

    CreateMapAll<TestInfra, DtoRead, DtoCreate, DtoSearch>();
  }
}