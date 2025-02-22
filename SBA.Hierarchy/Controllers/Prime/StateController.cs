using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using SBA.Hierarchy.App;

namespace SBA.Hierarchy.Controllers.Prime;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class StateController : CommonController<StateController, State>
{
  public StateController(
    ILogger<StateController> logger,
    IMapper mapper,
    IUOW uow) : base(logger, mapper, uow)
  {
    Repo = uow.States;

  }
}