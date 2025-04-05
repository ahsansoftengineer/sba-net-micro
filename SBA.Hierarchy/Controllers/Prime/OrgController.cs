using GLOB.Domain.Hierarchy;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;
[Route("api/Hierarchy/[controller]")]
[ApiController]
public class OrgController : CommonzController<OrgController, Org>
{
  public OrgController(IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.Orgs;
  }
}