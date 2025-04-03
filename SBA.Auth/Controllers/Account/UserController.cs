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
  private readonly UserManager<InfraUser> _userManager;
  // private readonly SignInManager<InfraUser> _signInManager;
  // private readonly RoleManager<InfraRole> _roleManager;
  // private readonly IConfiguration _config;
  private IUOW uOW { get; }
  public UserController(
    ILogger<AccountController> logger,
    IMapper mapper,
    UserManager<InfraUser> userManager,
    SignInManager<InfraUser> signInManager,
    RoleManager<InfraRole> roleManager,
    IUOW uow) : base(logger)
  {
    // Repo = uow.TestProjs;
    _userManager = userManager;
    // _signInManager = signInManager;
    // _roleManager = roleManager;
    // _config = config

  }
  [Authorize()]
  [HttpGet()]
  public async Task<IActionResult> Gets()
  {
    var list = _userManager.Users.ToList();
    var result = list.ToExtVMMulti();
    return Ok(result);
  }
  [HttpGet("{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _userManager.Users.FirstOrDefault(x => x.Id == Id);
    var result = data.ToExtVMSingle();
    return Ok(data);
  }
}