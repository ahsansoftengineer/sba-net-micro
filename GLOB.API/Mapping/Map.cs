using AutoMapper;
using GLOB.Domain.Base;

namespace GLOB.API.Mapper;
public partial class MapBase : Profile
{
  public MapBase()
  {
    MapCommon();
    MapAll();
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
    CreateMap<Entity, Dto>().ReverseMap();
    CreateMap<Entity, Search>().ReverseMap();
    CreateMap<Create, Entity>().ReverseMap();
    CreateMap<Entity, DtoSelect>().ReverseMap();
  }
}
