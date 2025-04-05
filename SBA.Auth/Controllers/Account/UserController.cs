// using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Domain.Model;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
public partial class UserController : AlphaController<UserController, InfraUser>
{
  private readonly ILogger<UserController> _logger;
  private readonly UserManager<InfraUser> _userManager;
  private readonly SignInManager<InfraUser> _signInManager;
  private readonly RoleManager<InfraRole> _roleManager;
  // private readonly IConfiguration _config;
  private IUOW uOW { get; }
  public UserController(
    IServiceProvider sp,
    UserManager<InfraUser> userManager,
    SignInManager<InfraUser> signInManager,
    RoleManager<InfraRole> roleManager,
    IUOW uow) : base(sp)
  {
    _userManager = userManager;
    _signInManager = signInManager;
    _roleManager = roleManager;
    // _config = config

  }
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
    var result = Mapper.Map<InfraUserDto>(data).ToExtVMSingle();
    return Ok(result);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] RegisterDto model)
  {

  }

  [HttpPut("{id:int}")]
  public async Task<IActionResult> Update(int id, [FromBody] DtoCreate data)
  {
    if (!ModelState.IsValid || id < 1) return InvalidId();
    try
    {
      var item = await Repo.Get(id);

      if (item == null) return InvalidId();

      var result = Mapper.Map(data, item);
      Repo.Update(item);
      await _unitOfWork.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }
}