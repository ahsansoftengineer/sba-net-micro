using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Infra.Helper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
[ApiController]
public partial class AccountController : AlphaController<AccountController>
{
  // private IRepoGenericz<AccountId> Repo = null;
  private readonly UserManager<UserInfra> _userManager;
  private readonly SignInManager<UserInfra> _signInManager;
  private readonly RoleManager<IdentityRole> _roleManager;
  private readonly IConfiguration _config;
  private IUOW uOW { get; }
  public AccountController(
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
  [HttpPost("[action]")]
  public async Task<IActionResult> Register([FromBody] RegisterDto model) 
  {
    var user = new UserInfra { UserName = model.Email, Email = model.Email, Title = model.FullName };
    var result = await _userManager.CreateAsync(user, model.Password);

    if (result.Succeeded)
    {
        return Ok(new { message = "User registered successfully!" });
    }

    return BadRequest(result.Errors);
  }

  [HttpPost("[action]")]
  public async Task<IActionResult> Login([FromBody] LoginDto model)  
  {
    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
    {
        var token = HelperAuth.GenerateJwtToken(user, _config);
        return Ok(new { token });
    }
    return Unauthorized("Invalid credentials.");
  }


  [HttpPost("[action]")]
  public async Task<IActionResult> Logout()  
  {
    await _signInManager.SignOutAsync();
    return Ok(new { message = "Logged out successfully" });
  }

  // [HttpPost("[action]")]
  // public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)  
  // {
  //   var principal = _jwtTokenService.GetPrincipalFromExpiredToken(model.Token);
  //       if (principal == null)
  //           return null;

  //       var userId = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
  //       var user = await _userManager.FindByIdAsync(userId);
  //       if (user == null || user.RefreshToken != model.RefreshToken || user.RefreshTokenExpiry < DateTime.UtcNow)
  //           return null;

  //       var newAccessToken = _jwtTokenService.GenerateAccessToken(user);
  //       var newRefreshToken = _jwtTokenService.GenerateRefreshToken();
  //       user.RefreshToken = newRefreshToken;
  //       user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);
  //       await _userManager.UpdateAsync(user);

  //       return new { AccessToken = newAccessToken, RefreshToken = newRefreshToken };  
  // }

  // [HttpPost("[action]")]
  // public async Task<IActionResult> VerifyEmail([FromQuery] string token, [FromQuery] string email) 
  // {
  //   var user = await _userManager.FindByEmailAsync(email);
  //   if (user == null)
  //     return BadRequest(new { message = "Email not Found" });

  //   var result = await _userManager.ConfirmEmailAsync(user, token);
  //   return Ok(new { message = "Your Email has been verified" });
  // }
}