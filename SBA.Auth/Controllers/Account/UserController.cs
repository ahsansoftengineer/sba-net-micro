using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Domain.Base;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    var users = _userManager.Users.ToList();
    var result = _mapper.Map<List<InfraUserDto>>(users).ToExtVMMulti();
    return Ok(result);
  }
  [HttpGet("{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _userManager.Users.FirstOrDefault(x => x.Id == Id);
    var result = _mapper.Map<InfraUserDto>(data).ToExtVMSingle();
    return Ok(result);
  }
  [HttpGet("[action]")]
  public async Task<IActionResult> GetsPaginate(PaginateRequestFilter<InfraUserDto> req)
  {
    IQueryable<InfraUser> query = _userManager.Users;
    var result = query.GetsPaginateQuery(req).ToExtMapSelectStrg();
    return await query.GetsPaginate(req);
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] RegisterDto model)
  {
    if (!ModelState.IsValid) return BadRequestz();
    InfraUser user = MapUser(model);
    var result = await _userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
      return Ok(new { message = "User registered successfully!" });
    }

    return BadRequest(result.Errors);
  }

  

  [HttpPut("{Id}")]
  public async Task<IActionResult> Update(string Id, [FromBody] UpdateUserDto data)
  {
    if (!ModelState.IsValid || string.IsNullOrEmpty(Id)) return InvalidId();
    try
    {
      var item = await _userManager.FindByIdAsync(Id);

      if (item == null) return InvalidId();
      item.Name = data.FullName;
      item.PhoneNumber = data.PhoneNumber;

      var result = await _userManager.UpdateAsync(item);
      await _uowInfra.Save();
      return Ok(result);
    }
    catch (Exception ex)
    {
      return CatchException(ex, nameof(Update));
    }
  }

  internal static InfraUser MapUser(RegisterDto model)
  {
    return new InfraUser
    {
      Id = Guid.NewGuid().ToString(),
      UserName = model.Email,
      Email = model.Email,
      PhoneNumber = model.PhoneNumber,
      Name = model.FullName
    };
  }
}