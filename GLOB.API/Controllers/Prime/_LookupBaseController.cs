using GLOB.API.Controllers.Base;
using GLOB.Domain.Base;
using Microsoft.AspNetCore.Mvc;

namespace GLOB.Projectz.Controllers;
public class _ProjectzLookupzBaseController : API_4_Default_Controller<_ProjectzLookupzBaseController, ProjectzLookupBase>
{
  public _ProjectzLookupzBaseController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookupBases;
  }
}