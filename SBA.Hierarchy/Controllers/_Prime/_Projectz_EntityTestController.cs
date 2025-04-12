using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class _Projectz_EntityTestController : Projectz_Default_Controller<_Projectz_EntityTestController, ProjectzEntityTest>
{
  public _Projectz_EntityTestController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowProjectz.TestProjs;
  }
}