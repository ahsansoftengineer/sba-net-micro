using GLOB.Hierarchy.Global;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;
[Route("[controller]")]
[ApiController]
public class _GlobalLookupzBaseController  : Projectz_Default_Controller<_GlobalLookupzBaseController , GlobalLookupzBase>
{
  public _GlobalLookupzBaseController (IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uow.GlobalLookupzBases;
  }
}