using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GLOB.Domain.Auth;
using GLOB.Infra.Data.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GLOB.Infra.Services;

public interface ITokenService
{
  string GenerateAccessToken(InfraUser user, IList<string> roles);
  string GenerateRefreshToken();
  Task SaveRefreshTokenAsync(string userId, string refreshToken, DateTime expiresAt);
}

public class TokenService : ITokenService
{
  private readonly UserManager<InfraUser> _userManager;
  protected readonly JwtSettings _jwtSettings;

  private readonly DBCntxtIdentity _context;

  public TokenService(
    IOptions<JwtSettings> jwtSettings,
    UserManager<InfraUser> userManager, DBCntxtIdentity context)
  {
    _jwtSettings = jwtSettings.Value;
    _userManager = userManager;
    _context = context;
  }

  public string GenerateAccessToken(InfraUser user, IList<string> roles)
  {
    var authClaims = new List<Claim>
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id),
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

    foreach (var role in roles)
    {
      authClaims.Add(new Claim(ClaimTypes.Role, role));
    }

    byte[] bytes = Encoding.UTF8.GetBytes(_jwtSettings.SecretKey);
    var authSigningKey = new SymmetricSecurityKey(bytes);
    var token = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.ExpireMinutes)),
      claims: authClaims,
      signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
    );

    return new JwtSecurityTokenHandler().WriteToken(token);
  }

  public string GenerateRefreshToken()
  {
    var randomBytes = new byte[64];
    using var rng = RandomNumberGenerator.Create();
    rng.GetBytes(randomBytes);
    return Convert.ToBase64String(randomBytes);
  }

  public async Task SaveRefreshTokenAsync(string userId, string refreshToken, DateTime expiresAt)
  {
    var token = new RefreshToken
    {
      UserId = userId,
      Token = refreshToken,
      ExpiresAt = expiresAt,
      IsRevoked = false
    };

    _context.RefreshTokens.Add(token);
    await _context.SaveChangesAsync();
  }
}
