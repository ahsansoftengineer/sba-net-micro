using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTO;
using PlatformService.Models;
using PlatformService.SyncDataServices.Http;

namespace EmployeeService.Controllers;

[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
  private readonly IEmployeeRepo _repo;
  private readonly IMapper _map;
  private readonly ICommandDataClient _cmdDataClient;

  public EmployeeController(
    IEmployeeRepo repo, 
    IMapper map,
    ICommandDataClient cmdDataClient
    )
  {
    _repo = repo;
    _map = map;
    _cmdDataClient = cmdDataClient;
  }

  [HttpGet]
  public ActionResult<IEnumerable<EmployeeReadDto>> GetEmployees()
  {
    Console.WriteLine("--> Getting Employees....");
    var result = _repo.GetAllEmployees();
    var dto = _map.Map<IEnumerable<EmployeeReadDto>>(result);
    return Ok(dto);
  }

  [HttpGet("{ID}", Name = "GetEmployeeByID")]
  public ActionResult<EmployeeReadDto> GetEmployeeByID(int ID)
  {
    Console.WriteLine("--> Getting Employees By ID....");
    var result = _repo.GetEmployeeById(ID);
    if(result != null)
    {
      var dto = _map.Map<EmployeeReadDto>(result);
      return Ok(dto);
    }

    return NotFound();
  }

  [HttpPost]
  public async Task<ActionResult<EmployeeReadDto>> CreateEmployee(EmployeeCreateDto dto)
  {
    Console.WriteLine("--> Creating Employees....");
    var model = _map.Map<Employee>(dto);
    _repo.CreateEmployee(model);
    _repo.SaveChanges();

    var result = _map.Map<EmployeeReadDto>(model);

    // try {
    //   await _cmdDataClient.SendEmployeeToCommand(result);
    // }
    // catch(Exception ex) {
    //   Console.WriteLine($"--> Could not send synchronously: {ex.Message}");
    // }
    return CreatedAtRoute(
      nameof(GetEmployeeByID), 
      new { Id = model.ID}, 
      model
    );
  }
}