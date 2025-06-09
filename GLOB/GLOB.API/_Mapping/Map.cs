using AutoMapper;
using GLOB.Infra.Model.Base;

namespace GLOB.API.Mapper;

public partial class API_Base_Mapper : Profile
{
  public API_Base_Mapper()
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

  // Three Param
  protected void CreateMapAll<TEntity, TDtoCreateUpdateRead, TDtoSearch>()
  {
    CreateMapAll<TEntity, TDtoCreateUpdateRead, TDtoSearch, DtoSelect>();
  }
  // Four Param
  protected void CreateMapAll<TEntity, TDtoCreateUpdate, TDtoRead, TDtoSearch>()
  {
    CreateMapAll<TEntity, TDtoCreateUpdate, TDtoCreateUpdate, TDtoRead, TDtoSearch, DtoSelect>();
  }
  // Six Param
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