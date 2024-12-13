using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace CommandsService.Controllers;

[Route("/api/c/[controller]")]
[ApiController]
public class PlatformsController : ControllerBase
{
  public PlatformsController()
  {

  }
  [HttpGet]
  public ActionResult TestInboundConnectionS()
  {
    Console.WriteLine("--> Inbound GET # Command Service");

    return Ok("Inbound test of from Platforms Controller");
  }
  [HttpPost]
  public ActionResult TestInboundConnection()
  {
    Console.WriteLine("--> Inbound POST # Command Service");

    return Ok("Inbound test of from Platforms Controller");
  }
}