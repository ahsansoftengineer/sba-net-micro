using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;

[Route("api/Hierarchy/[controller]")]
[ApiController]
public class BGController : CommonzController<BGController, BG>
{
  public BGController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.BGs;
  }
}