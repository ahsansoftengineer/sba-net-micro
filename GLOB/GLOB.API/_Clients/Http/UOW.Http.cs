// Need to Work on That Service for Always

using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class UOW_API_Httpz
{
  private readonly Option_Http _option_Http;
  private API_Httpz _API_Httpz_AuthLookup;

  public UOW_API_Httpz(IServiceProvider sp)
  {
    _option_Http = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.API_Httpz;
  }

  public API_Httpz API_Httpz_AuthLookup => _API_Httpz_AuthLookup = new API_Httpz(_option_Http.Auth, Srvc.Auth, Controllerz.ProjectzLookup) ;
}