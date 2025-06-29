// Need to Work on That Service for Always

using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class UOW_API_Httpz
{
  private readonly IServiceProvider _sp;
  private readonly Option_Http _option_Http;
  private API_Client_Http _ClientHttpAuth;

  public UOW_API_Httpz(IServiceProvider sp)
  {
    _sp = sp;
    _option_Http = sp.GetSrvc<IOptions<Option_App>>().Value.Clientz.Http_Host;
  }

  public API_Client_Http ClientHttpAuth => _ClientHttpAuth ??= new API_Client_Http(_sp, _option_Http.Auth, PrefixHttp.Auth, Controllerz.Auth.ProjectzLookup) ;
}