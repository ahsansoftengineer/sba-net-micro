// Need to Work on That Service for Always

using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class UOW_Httpz
{
  private readonly ClientzHttpSettings _UrlzHttp;
  private Httpz _Httpz_AuthLookup;

  public UOW_Httpz(IServiceProvider sp)
  {
    _UrlzHttp = sp.GetSrvc<IOptions<AppSettings>>().Value.Clientz.Httpz;
  }

  public Httpz Httpz_AuthLookup => _Httpz_AuthLookup = new Httpz(_UrlzHttp.Auth, Srvc.Auth, Controllerz.ProjectzLookup) ;
}