using GLOB.API.Controllers.Base;

namespace GLOB.Projectz.Controllers;
public class _ProjectzLookupBaseController : API_4_Default_Controller<_ProjectzLookupBaseController, ProjectzLookupBase>
{
  public _ProjectzLookupBaseController(
    IServiceProvider srvcProvider) : base(srvcProvider)
  {
    _repo = _uowInfra.ProjectzLookupBases;
  }
}