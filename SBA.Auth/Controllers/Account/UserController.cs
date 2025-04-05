// using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
public partial class UserController : AlphaController<UserController>
{
  private readonly UserManager<InfraUser> _userManager;
  private readonly SignInManager<InfraUser> _signInManager;
  private readonly RoleManager<InfraRole> _roleManager;
  // private readonly IConfiguration _config;
  private IUOW uOW { get; }
  public UserController(
    IServiceProvider srvcProvider,
    UserManager<InfraUser> userManager,
    SignInManager<InfraUser> signInManager,
    RoleManager<InfraRole> roleManager,
    IUOW uow) : base(srvcProvider)
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
    var result = _mapper.Map<InfraUserDto>(data).ToExtVMSingle();
    return Ok(result);
  }

  // [HttpPost]
  // public async Task<IActionResult> Create([FromBody] RegisterDto model)
  // {

  // }

  // [HttpPut("{id:int}")]
  // public async Task<IActionResult> Update(int id, [FromBody] DtoCreate data)
  // {
  //   if (!ModelState.IsValid || id < 1) return InvalidId();
  //   try
  //   {
  //     var item = await _repo.Get(id);

  //     if (item == null) return InvalidId();

  //     var result = _mapper.Map(data, item);
  //     _repo.Update(item);
  //     await _unitOfWork.Save();
  //     return Ok(result);
  //   }
  //   catch (Exception ex)
  //   {
  //     return CatchException(ex, nameof(Update));
  //   }
  // }
}