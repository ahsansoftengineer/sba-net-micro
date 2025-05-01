using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GLOB.Domain.Auth;
using GLOB.Infra.Data.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SBA.Projectz.Data;

namespace SBA.Auth.Services;

public interface ITokenService
{
  string GenerateAccessToken(InfraUser user, IList<string> roles);
  string GenerateRefreshToken();
  ClaimsPrincipal? GetPrincipalFromExpiredToken(string token);
  Task SaveRefreshTokenAsync(string userId, string refreshToken, DateTime expiresAt);
}

public class TokenService : ITokenService
{
  private readonly UserManager<InfraUser> _userManager;
  protected readonly JwtSettings _jwtSettings;

  private readonly DBCtxProjectz _context;

  public TokenService(
    IOptions<JwtSettings> jwtSettings,
    UserManager<InfraUser> userManager, 
    DBCtxProjectz context)
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

    var token = new JwtSecurityToken(
      issuer: _jwtSettings.Issuer,
      audience: _jwtSettings.Audience,
      expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(_jwtSettings.ExpireMinutes)),
      claims: authClaims,
      signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
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
      InfraUserId = userId,
      Token = refreshToken,
      ExpiresAt = expiresAt,
      IsRevoked = false
    };

    _context.RefreshTokens.Add(token);
    await _context.SaveChangesAsync();
  }
  public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            ValidateLifetime = false, // ignore expiration
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            IssuerSigningKey = GetSymmetricSecurityKey()
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                return null;
            }

            return principal;
        }
        catch
        {
            return null;
        }
    }

    private SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
    }
}
