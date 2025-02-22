using AutoMapper;
using GLOB.Domain.Base;
using GLOB.Domain.Common;
using System.Net;

namespace GLOB.API.Config;
public class MapInitBase : Profile
{
  public MapInitBase()
  {
    // DTOs => Domain
    // Entity => Infrastructure
    // Cannot Put in This Class in Domain because Domain cannot be Dependent on Infrastructure
    // API is Depending on both Domain and Infrastructure

    // Future Reference
    //CreateMap<Org, OrgDto>();
    //CreateMap<Org, BaseDtoRelation>();
    //CreateMap<Org, OrgDtoWithSystemzs>();
    //CreateMap<Org, OrgDtoSearch>();
    //CreateMap<BaseDtoCreate, Org>(); //.ReverseMap()

    // CreateMap(typeof(PagedList<>), typeof(PagedList<>));
    // CreateMap(typeof(IPagedList<>), typeof(PaginateResponse<>));
  }


  protected void CreateMapCommon<Entity>()
  {
    this.CreateMapAll<Entity, BaseDtoFull, BaseDtoCreate, BaseDtoSearchFull>();
  }

  protected void CreateMapAllWithChild<Entity, Dto, Create, Search, Child>() // Relation
  {
    CreateMapAll<Entity, Dto, Create, Search>();
    CreateMap<Entity, Child>();
  }
  protected void CreateMapAll<Entity, Dto, Create, Search>() // Relation
  {
    CreateMap<Entity, Dto>();
    // CreateMapPagedList<Entity, Dto>(); // As per my Own Implementation No Need to Mapped
    CreateMapSingle<Entity, Dto>();
    CreateMapMulti<Entity,  BaseDtoSelect>();
    CreateMap<Entity, Search>();
    CreateMap<Create, Entity>();
  }
  protected void CreateMapSingle<Src, Dest>()
  {
    CreateMap<Src, BaseDtoSingleRes<Dest>>()
      .ForMember(d => d.Record, c => c.MapFrom(y => y))
      .ForMember(d => d.Status, c => c.MapFrom(y => HttpStatusCode.OK));
  }
  protected void CreateMapMulti<Src, Dest>()
  {
    CreateMap<List<Src>, BaseDtoMultiRes<Dest>>()
      .ForMember(d => d.Records, c => c.MapFrom(y => y))
      .ForMember(d => d.Status, c => c.MapFrom(y => HttpStatusCode.OK));
  }
   

}
