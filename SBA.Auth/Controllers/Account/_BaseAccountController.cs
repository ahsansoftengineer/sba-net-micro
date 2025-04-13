using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using SBA.Auth.Services;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
public abstract class AccountBaseController<T> : API_1_ErrorController<T>
{
  // private IRepoGenericz<AccountId> _repo = null;
  protected readonly UserManager<InfraUser> _userManager;
  protected readonly SignInManager<InfraUser> _signInManager;
  protected readonly SmtpEmailSender _emailSender;

  protected IUOW_Projectz _uowProjectz { get; }
  public AccountBaseController(
    IServiceProvider srvcProvider
  ) : base(srvcProvider)
  {
    _userManager = GetSrvc<UserManager<InfraUser>>();
    _signInManager = GetSrvc<SignInManager<InfraUser>>();;
    _uowProjectz = GetSrvc<IUOW_Projectz>();
    _emailSender = GetSrvc<SmtpEmailSender>();
  }
}