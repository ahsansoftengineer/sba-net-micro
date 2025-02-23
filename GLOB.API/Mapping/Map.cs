using AutoMapper;
using GLOB.Domain.Base;

namespace GLOB.API.Config;
public class MapInitBase : Profile
{
  public MapInitBase()
  {
    //CreateMap<Org, OrgDto>();
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
