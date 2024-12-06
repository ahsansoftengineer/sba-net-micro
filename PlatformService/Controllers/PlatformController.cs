using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTO;
using PlatformService.Models;

namespace PlatformService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlatformController : ControllerBase
{
  private readonly IPlatformRepo _repo;
  private readonly IMapper _map;

  public PlatformController(IPlatformRepo repo, IMapper map)
  {
    _repo = repo;
    _map = map;
  }

  [HttpGet]
  public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
  {
    Console.WriteLine("--> Getting Platforms....");
    var result = _repo.GetAllPlatforms();
    var dto = _map.Map<IEnumerable<PlatformReadDto>>(result);
    return Ok(dto);
  }

  [HttpGet("{ID}", Name = "GetPlatformByID")]
  public ActionResult<PlatformReadDto> GetPlatformByID(int ID)
  {
    Console.WriteLine("--> Getting Platforms By ID....");
    var result = _repo.GetPlatformById(ID);
    if(result != null)
    {
      var dto = _map.Map<PlatformReadDto>(result);
      return Ok(dto);
    }

    return NotFound();
  }

  [HttpPost]
  public ActionResult<PlatformReadDto> CreatePlatform(PlatformCreateDto dto)
  {
    Console.WriteLine("--> Creating Platforms....");
    var model = _map.Map<Platform>(dto);
    _repo.CreatePlatform(model);
    _repo.SaveChanges();

    var result = _map.Map<PlatformReadDto>(model);
    return CreatedAtRoute(
      nameof(GetPlatformByID), 
      new { Id = model.ID}, 
      model
    );
  }
}