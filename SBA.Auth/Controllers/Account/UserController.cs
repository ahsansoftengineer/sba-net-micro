using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
public partial class UserController : AlphaController<AccountController>
{
  private readonly UserManager<UserInfra> _userManager;
  private readonly SignInManager<UserInfra> _signInManager;
  private readonly RoleManager<IdentityRole> _roleManager;
  private readonly IConfiguration _config;
  private IUOW uOW { get; }
  public UserController(
    ILogger<AccountController> logger,
    IMapper mapper,
    UserManager<UserInfra> userManager,
    SignInManager<UserInfra> signInManager,
    RoleManager<IdentityRole> roleManager,
    IUOW uow) : base(logger)
  {
    // Repo = uow.TestProjs;
    _userManager = userManager;
    _signInManager = signInManager;
    _roleManager = roleManager;

  }
  [Authorize()]
  [HttpGet()]
  public async Task<IActionResult> GetUsers()
  {
    var list = _userManager.Users.ToList();
    var result = list.ToExtVMMulti();
    return Ok(result);
  }
  [HttpGet("{id:int}")]
  public async Task<IActionResult> GetUser(string Id)
  {
    var data = _userManager.Users.FirstOrDefault(x => x.Id == Id);
    var result = data.ToExtVMSingle();
    return Ok(data);
  }
}