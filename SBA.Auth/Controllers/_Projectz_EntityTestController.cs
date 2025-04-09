using GLOB.Domain.Projectz;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Auth.Controllers.Test;
[Route("api/Auth/[controller]")]
[ApiController]
public class _Projectz_EntityTestController : ProjectzCommonController<_Projectz_EntityTestController, ProjectzEntityTest>
{
  public _Projectz_EntityTestController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.TestProjs;
  }
}