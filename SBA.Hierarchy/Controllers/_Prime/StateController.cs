using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class StateController : Projectz_Default_Controller<StateController, State>
{
  public StateController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.States;
  }
}