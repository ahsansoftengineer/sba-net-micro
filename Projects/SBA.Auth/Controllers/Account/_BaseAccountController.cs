using GLOB.API.Config.Configz;
using GLOB.API.Config.DI;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Infra.Data.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SBA.Auth.Services;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
public abstract class AccountBaseController<T> : API_1_ErrorController<T>
{
  // private IRepoGenericz<AccountId> _repo = null;
  protected readonly JwtSettings _jwt;
  protected readonly UserManager<InfraUser> _userManager;
  protected readonly SignInManager<InfraUser> _signInManager;
  protected readonly TokenService _tokenService;
  protected readonly SmtpEmailSender _emailSender;
  protected readonly DBCtxProjectz _ctx;

  protected IUOW_Projectz _uowProjectz { get; }
  public AccountBaseController(
    IServiceProvider srvcProvider
  ) : base(srvcProvider)
  {
    _ctx = GetSrvc<DBCtxProjectz>();
    _uowProjectz = GetSrvc<IUOW_Projectz>();

    _userManager = GetSrvc<UserManager<InfraUser>>();
    _signInManager = GetSrvc<SignInManager<InfraUser>>();;
    _tokenService = GetSrvc<TokenService>();
    _emailSender = GetSrvc<SmtpEmailSender>();
    
    _jwt = GetSrvc<IOptions<JwtSettings>>().Value;
  }
}