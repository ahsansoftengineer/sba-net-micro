// Need to Work on That Service for Always

using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class UOW_API_Httpz
{
  private readonly IServiceProvider _sp;
  private readonly Option_Http _option_Http;
  private API_Client_Http _API_Httpz_AuthLookup;

  public UOW_API_Httpz(IServiceProvider sp)
  {
    _sp = sp;
    _option_Http = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.API_Client_Http;
  }

  public API_Client_Http Http_Auth_Lookup => _API_Httpz_AuthLookup = null;//new API_Client_Http(_sp, _option_Http.Auth, PrefixHttp.Auth, Controllerz.Auth.ProjectzLookup) ;
}