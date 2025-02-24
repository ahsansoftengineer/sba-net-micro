using AutoMapper;
using GLOB.API.Controllers.Base;
using GLOB.Domain.Auth;
using GLOB.Infra.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SBA.Projectz.Data;

namespace SBA.Auth.Controllers;
[Route("api/Auth/[controller]")]
[ApiController]
public partial class AccountController : AlphaController<AccountController>
{
  // private IRepoGenericz<AccountId> Repo = null;
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
    return null;  
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login([FromBody] LoginDto model)  
  {
    return null;  
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

}