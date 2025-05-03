using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using GLOB.API.Config.Model;
using GLOB.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SBA.Projectz.Data;

namespace SBA.Auth.Services;

public class TokenService
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

  public string GenerateAccessToken(InfraUser user, IList<string> roles, out string JTI)
  {
    JTI = Guid.NewGuid().ToString();
    var authClaims = new List<Claim>
    {
      new Claim(ClaimTypes.NameIdentifier, user.Id),
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(JwtRegisteredClaimNames.Jti, JTI),
      new Claim(JwtRegisteredClaimNames.Sub, user.Id)
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
      signingCredentials: new SigningCredentials(_jwtSettings.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
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

  public async Task SaveRefreshTokenAsync(string userId, string refreshToken, string IP, string JTI)
  {
    var token = new RefreshToken
    {
      InfraUserId = userId,
      Token = refreshToken,
      IsUsed = false,
      IsRevoked = false,
      JwtId = JTI,
      CreatedByIp = IP,
      ExpiresAt = DateTime.UtcNow.AddDays(7),
      CreatedAt = DateTimeOffset.UtcNow,
    };

    await _context.RefreshTokens.AddAsync(token);
    await _context.SaveChangesAsync();
  }
  public ClaimsPrincipal? GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = _jwtSettings.Issuer,
            ValidAudience = _jwtSettings.Audience,
            ValidateIssuer = _jwtSettings.ValidateIssuer,
            ValidateAudience = _jwtSettings.ValidateAudience,
            ValidateLifetime = _jwtSettings.ValidateLifetime,
            ValidateIssuerSigningKey = _jwtSettings.ValidateIssuerSigningKey,
            IssuerSigningKey = _jwtSettings.GetSymmetricSecurityKey()
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
}
