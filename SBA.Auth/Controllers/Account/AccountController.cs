using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
[ApiController]
public partial class AccountController : AlphaController<AccountController>
{
  // private IRepoGenericz<AccountId> Repo = null;
  private readonly UserManager<UserInfra> _userManager;
  private readonly SignInManager<UserInfra> _signInManager;
  private readonly IConfiguration _config;
  private readonly RoleManager<IdentityRole> _roleManager;
  private IUOW uOW { get; }
  public AccountController(
    ILogger<AccountController> logger,
    IMapper mapper,
    IUOW uow) : base(logger)
  {
    // Repo = uow.TestProjs;

  }
  [HttpPost("register")]
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

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto model)  
  {
    var user = await _userManager.FindByEmailAsync(model.Email);
    if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
    {
        var token = GenerateJwtToken(user);
        return Ok(new { token });
    }
    return Unauthorized("Invalid credentials.");;  
  }


  [HttpPost("logout")]
  public async Task<IActionResult> Logout()  
  {
    return null;  
  }

  [HttpPost("refresh-token")]
  public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenDto model)  
  {
    return null;  
  }

  [HttpPost("verify-email")]
  public async Task<IActionResult> VerifyEmail([FromQuery] string token, [FromQuery] string email) 
  {
    return null;  
  }


  // Private Functions
  private string GenerateJwtToken(UserInfra user)
  {
      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
      var claims = new[]
      {
          new Claim(JwtRegisteredClaimNames.Sub, user.Email),
          new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
          new Claim("UserId", user.Id)
      };

      var token = new JwtSecurityToken(
          issuer: _config["Jwt:Issuer"],
          audience: _config["Jwt:Audience"],
          claims: claims,
          expires: DateTime.UtcNow.AddHours(1),
          signingCredentials: creds);

      return new JwtSecurityTokenHandler().WriteToken(token);
  }
}