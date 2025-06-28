// Need to Work on That Service for Always

using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class UOW_Httpz
{
  private readonly Option_Http _option_Http;
  private Httpz _Httpz_AuthLookup;

  public UOW_Httpz(IServiceProvider sp)
  {
    _option_Http = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.Httpz;
  }

  public Httpz Httpz_AuthLookup => _Httpz_AuthLookup = new Httpz(_option_Http.Auth, Srvc.Auth, Controllerz.ProjectzLookup) ;
}