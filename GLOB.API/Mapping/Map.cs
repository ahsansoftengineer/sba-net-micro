using AutoMapper;
using GLOB.Domain.Base;
using GLOB.Domain.Projectz;

namespace GLOB.API.Mapper;
public class MapBase : Profile
{
  public MapBase()
  {
    // CreateMap<TestInfra, DtoCreate>();
  }
  protected void CreateMapCommon<Entity>()
  {
    this.CreateMapAll<Entity, DtoRead, DtoCreate, DtoSearch>();
  }

  protected void CreateMapAllWithChild<Entity, Dto, Create, Search, Child>()
  {
    CreateMapAll<Entity, Dto, Create, Search>();
    CreateMap<Entity, Child>();
  }
  protected void CreateMapAll<Entity, Dto, Create, Search>()
  {
    CreateMap<Entity, Dto>();
    CreateMap<Entity, Search>();
    CreateMap<Create, Entity>();
  }
}
