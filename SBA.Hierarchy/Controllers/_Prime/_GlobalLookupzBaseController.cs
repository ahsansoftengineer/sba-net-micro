using GLOB.Hierarchy.Global;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Controllers.Base;

namespace SBA.Hierarchy.Controllers.Prime;
[Route("[controller]")]
[ApiController]
public class _GlobalLookupzzBaseController  : Projectz_Default_Controller<_GlobalLookupzzBaseController , GlobalLookupzzBase>
{
  public _GlobalLookupzzBaseController (IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowProjectz.GlobalLookupzzBases;
  }
}