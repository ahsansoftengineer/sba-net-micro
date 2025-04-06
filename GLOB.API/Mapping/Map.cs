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
  // Used When The Base (Dtos and Entity)
  protected void CreateMap_Entity_DefaultDtos<TEntity>()
    where TEntity : EntityBase
  {
    CreateMapAll<TEntity, DtoCreate, DtoUpdate, DtoRead, DtoSearch, DtoSearch>();
  }

  protected void CreateMapAll<TEntity, TDtoCreateUpdate, TDtoRead, TDtoSearch>()
  {
    CreateMapAll<TEntity, TDtoCreateUpdate, TDtoCreateUpdate, TDtoSearch, DtoSelect>();
  }
  // Used When The Dtos and Entity has Maching Properties
  protected void CreateMapAll<TEntity, TDtoCreateUpdate, TDtoRead, TDtoSearch, TDtoSelect>()
  {
    CreateMapAll<TEntity, TDtoCreateUpdate, TDtoCreateUpdate, TDtoSearch, TDtoSelect>();
  }

  protected void CreateMapAll<TEntity, TDtoCreate, TDtoUpdate, TDtoRead, TDtoSearch, TDtoSelect>()
  {
    CreateMap<TDtoCreate, TEntity>().ReverseMap();
    CreateMap<TDtoUpdate, TEntity>().ReverseMap();

    CreateMap<TEntity, TDtoRead>().ReverseMap();
    CreateMap<TEntity, TDtoSearch>().ReverseMap();
    CreateMap<TEntity, TDtoSelect>().ReverseMap();
  }
}

// .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.DateFrom))
// .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(src => src.DateTo));