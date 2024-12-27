using AutoMapper;
using PlatformService.DTO;
using PlatformService.Models;
namespace PlatformService.Profiles;
public class PlatformsProfile : Profile
{
  public PlatformsProfile()
  {
    // Source -> Target
    CreateMap<Platform, PlatformReadDto>();
    CreateMap<PlatformCreateDto, Platform>();

    CreateMap<Employee, EmployeeReadDto>();
    CreateMap<EmployeeCreateDto, Employee>();
  }
}