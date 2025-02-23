using GLOB.Domain.Base;
using GLOB.Domain.Projectz;

namespace GLOB.API.Mapper;
public class MapAll : MapBase
{
  public MapAll() : base()
  {

    // CreateMapAll<TestInfra, DtoRead, DtoCreate, DtoSearch>();
    // CreateMap<OUDtoCreate, OUDtoCreateToEntity>();
    //.ForMember(d => d.LogoImg, c => c.MapFrom(y => y.LogoImg.Name))
    //.ForMember(d => d.TopImg, c => c.MapFrom(y => y.TopImg.Name))
    //.ForMember(d => d.WarningImg, c => c.MapFrom(y => y.WarningImg.Name))
    //.ForMember(d => d.FooterImg, c => c.MapFrom(y => y.FooterImg.Name));
  }
}