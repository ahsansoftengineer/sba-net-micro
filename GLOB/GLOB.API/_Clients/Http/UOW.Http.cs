// Need to Work on That Service for Always

using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Http;

public partial class UOW_Httpz
{
  public readonly AppSettings _appSettings;
  private Httpz _AuthLookupBaseHttpz;

  public UOW_Httpz(IServiceProvider sp)
  {
    _appSettings = sp.GetSrvc<IOptions<AppSettings>>().Value;
  }

  public Httpz AuthLookupBaseHttpz => _AuthLookupBaseHttpz = new Httpz(_appSettings.SrvcHttp.Auth, Srvc.Auth, Controllerz.ProjectzLookup) ;
}