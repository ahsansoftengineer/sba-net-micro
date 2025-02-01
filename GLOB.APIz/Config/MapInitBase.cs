using AutoMapper;
using System.Net;
using X.PagedList;

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
    //CreateMapPagedList<Org, OrgDto>();
    //CreateMap<Org, BaseDtoRelation>();
    //CreateMap<Org, OrgDtoWithSystemzs>();
    //CreateMap<Org, OrgDtoSearch>();
    //CreateMap<BaseDtoCreate, Org>(); //.ReverseMap()

    CreateMap(typeof(PagedList<>), typeof(PagedList<>));
  }


  protected void CreateMapCommon<Entity>()
  {
    this.CreateMapAll<Entity, CommonDto, CommonDtoCreate, CommonDtoSearch>();
  }
  protected void CreateMapCommonStatus<Entity>()
  {
    this.CreateMapAll<Entity, CommonStatusDto, CommonStatusDtoCreate, CommonStatusDtoSearch>();
  }
  protected void CreateMapAllWithChild<Entity, Dto, Create, Search, Child>() // Relation
  {
    CreateMapAll<Entity, Dto, Create, Search>();
    CreateMap<Entity, Child>();
  }
  protected void CreateMapAll<Entity, Dto, Create, Search>() // Relation
  {
    CreateMap<Entity, Dto>();
    CreateMapPagedList<Entity, Dto>();
    CreateMapSingle<Entity, Dto>();
    CreateMap<Entity, BaseDtoRelation>();
    CreateMap<Entity, Search>();
    CreateMap<Create, Entity>();
  }
  protected void CreateMapSingle<Src, Dest>()
  {
    CreateMap<Src, BaseDtoSingle<Dest>>()
      .ForMember(d => d.Record, c => c.MapFrom(y => y))
      .ForMember(d => d.Status, c => c.MapFrom(y => HttpStatusCode.OK));
  }

  protected void CreateMapPagedList<Src, Dest>()
  {
    CreateMap<IPagedList<Src>, PaginateResponse<Dest>>()
      .ForMember(d => d.Records, c => c.MapFrom(y => y.ToList()))
      .ForMember(d => d.Count, c => c.MapFrom(s => s.TotalItemCount))
      .ForMember(d => d.PageNo, c => c.MapFrom(s => s.PageNumber))
      .ForMember(d => d.PageSize, c => c.MapFrom(s => s.PageSize))
      .ForMember(d => d.Status, c => c.MapFrom(s => HttpStatusCode.OK));
  }
}
