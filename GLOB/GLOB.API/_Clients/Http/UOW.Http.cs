// Need to Work on That Service for Always

using GLOB.API.Config.Configz;
using GLOB.API.Config.Extz;
using Microsoft.Extensions.Options;

namespace GLOB.API.Clientz;

public partial class UOW_Httpz
{
  private readonly AppSettings _appSettings;
  private Httpz _Httpz_AuthLookup;

  public UOW_Httpz(IServiceProvider sp)
  {
    _appSettings = sp.GetSrvc<IOptions<AppSettings>>().Value;
  }

  public Httpz Httpz_AuthLookup => _Httpz_AuthLookup = new Httpz(_appSettings.Clientz.Httpz.Auth, Srvc.Auth, Controllerz.ProjectzLookup) ;
}