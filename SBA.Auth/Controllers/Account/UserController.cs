using GLOB.Domain.Auth;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SBA.Auth.Controllers;

[Route("[controller]")]
public partial class UserController : AccountBaseController<UserController>
{
  private readonly RoleManager<InfraRole> _roleManager;
  public UserController(
    IServiceProvider srvcProvider,
    RoleManager<InfraRole> roleManager) : base(srvcProvider)
  {
    _roleManager = roleManager;

  }
  [HttpGet()]
  public async Task<IActionResult> Gets()
  {
    var users = _userManager.Users.ToList();
    var result = _mapper.Map<List<InfraUserDtoRead>>(users).ToExtResVMList();
    return Ok(result);
  }
  [HttpGet("{Id}")]
  public async Task<IActionResult> Get(string Id)
  {
    var data = _userManager.Users.FirstOrDefault(x => x.Id == Id);
    var result = _mapper.Map<InfraUserDtoRead>(data).ToExtResVMSingle();
    return Ok(result);
  }

  // [HttpGet("[action]")]
  // public async Task<IActionResult> GetsPaginate(DtoPageReq<InfraUserDtoSearch> req)
  // {
  //   var query = _userManager.Users.ToExtQueryFilterSortInclude(req);
  //   var mappedQuery = query.ToExtMapQuery<>()
  //   var result = query.GetsPaginateOptions<InfraUser, string, InfraUserDtoSearch>(req);
  //   return await result.GetsPaginate(req);
  // }

  // [HttpGet("[action]")]
  // public async Task<IActionResult> GetsPaginateOptions(DtoPageReq<InfraUser> req)
  // {
  //   IQueryable<InfraUser> query = _userManager.Users;
  //   var result = query.ToExtQueryFilterSortInclude(req).GetsPaginateOptions<InfraUser, string>();
  //   return  Ok(result);
  // }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] RegisterDto model)
  {
    if (!ModelState.IsValid) return Res_BadRequestModel();
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
    if (string.IsNullOrEmpty(Id)) return Res_NotFoundId(Id);
    try
    {
      var item = await _userManager.FindByIdAsync(Id);

      if (item == null) return Res_NotFoundId(Id);
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