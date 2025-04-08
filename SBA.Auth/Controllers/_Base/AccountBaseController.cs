using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
public abstract class AccountBaseController<T> : AlphaController<T>
{
  // private IRepoGenericz<AccountId> _repo = null;
  protected readonly UserManager<InfraUser> _userManager;
  protected readonly SignInManager<InfraUser> _signInManager;
  private readonly IConfiguration _config;

  protected IUOW _uow { get; }
  public AccountBaseController(
    IServiceProvider srvcProvider
  ) : base(srvcProvider)
  {
    _userManager = GetSrvc<UserManager<InfraUser>>();
    _signInManager = GetSrvc<SignInManager<InfraUser>>();;
    _uow = GetSrvc<IUOW>();;
    _config = GetSrvc<IConfiguration>();;
  }
}